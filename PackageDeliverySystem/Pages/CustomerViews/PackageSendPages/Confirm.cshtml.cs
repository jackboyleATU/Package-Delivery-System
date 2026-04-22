using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;
using Stripe.Checkout;
using Stripe.Climate;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageSendPages
{
    public class ConfirmModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Package Package { get; set; }
        public string CustomerName { get; set; }

        public IActionResult OnGet()
        {
            // Rebuild package from TempData
            if (TempData["Package_CustomerId"] is not int customerId)
            {
                return RedirectToPage("PackageSend");
            }

            Package = new Package
            {
                CustomerId = customerId,
                RecipientName = TempData["Package_RecipientName"] as string ?? "",
                Destination = TempData["Package_Destination"] as string ?? "",
                Type = (Package.PackageType)(int)TempData["Package_Type"]!,
                Weight = double.Parse(TempData["Package_Weight"] as string ?? "0"),
                DeliveryDate = (DateTime)TempData["Package_DeliveryDate"]!,
                Cost = double.Parse(TempData["Package_Cost"] as string ?? "0")
            };

            // Keep TempData alive for the POST
            TempData.Keep();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (TempData["Package_CustomerId"] is not int customerId)
            {
                return RedirectToPage("PackageSend");
            }

            var package = new Package
            {
                CustomerId = customerId,
                RecipientName = TempData["Package_RecipientName"] as string ?? "",
                Destination = TempData["Package_Destination"] as string ?? "",
                Type = (Package.PackageType)(int)TempData["Package_Type"]!,
                Weight = double.Parse(TempData["Package_Weight"] as string ?? "0"),
                DeliveryDate = (DateTime)TempData["Package_DeliveryDate"]!,
                Cost = double.Parse(TempData["Package_Cost"] as string ?? "0"),
                Status = Package.PackageStatus.AwaitingPickup,
                AttemptedDeliveries = 0,
                Route = Package.DeliveryRoute.North  // Assign default or based on destination
            };
            if (string.IsNullOrWhiteSpace(package.OrderNumber))
            {
                var latest = _unitOfWork.PackageRepo.GetAll()
                             .OrderByDescending(p => p.Id)
                             .FirstOrDefault();

                string newOrderNumber;

                if (latest == null || string.IsNullOrWhiteSpace(latest.OrderNumber))
                {
                    newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                }
                else
                {
                    var last = latest.OrderNumber.Trim();
                    var lastDash = last.LastIndexOf('-');

                    if (lastDash >= 0 && lastDash < last.Length - 1)
                    {
                        var prefix = last.Substring(0, lastDash + 1);
                        var numericPart = last.Substring(lastDash + 1);

                        if (int.TryParse(numericPart, out var seq))
                        {
                            var nextSeq = (seq + 1).ToString().PadLeft(numericPart.Length, '0');
                            newOrderNumber = prefix + nextSeq;
                        }
                        else
                        {
                            newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                        }
                    }
                    else
                    {
                        newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                    }
                }

                package.OrderNumber = newOrderNumber;

            }

            _unitOfWork.PackageRepo.Add(package);
            _unitOfWork.Save();

            // Ensure the page-level Package property references the saved package
            Package = package;

            // Build success/cancel URLs dynamically and include orderId.
            // Append Stripe's session id placeholder so you can validate the session if needed.
            var successUrl = Url.Page("/CustomerViews/OrderConfirm", null, new { orderId = package.Id }, Request.Scheme)
                             + "?session_id={CHECKOUT_SESSION_ID}";
            var cancelUrl = Url.Page("/CustomerViews/Index", null, null, Request.Scheme);

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                      PriceData= new SessionLineItemPriceDataOptions
                      {
                          // Use the saved package instance for cost -> cents
                          UnitAmount = (long)(package.Cost * 100),
                          Currency="eur",
                          ProductData = new SessionLineItemPriceDataProductDataOptions
                          {
                              Name = "LKPostal Service"
                          }
                      },

                    Quantity = 1,
                  },
                },
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },

                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }
    }
}
