using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

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
                AttemptedDeliveries = 0
            };

            _unitOfWork.PackageRepo.Add(package);
            _unitOfWork.Save();

            TempData["SuccessMessage"] = "Package sent successfully!";
            return RedirectToPage("/Index");
        }
    }
}
