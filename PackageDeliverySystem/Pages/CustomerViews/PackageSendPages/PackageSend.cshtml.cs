using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageSendPages
{
    public class PackageSendModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public PackageSendModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Package Package { get; set; }

        public SelectList Customers { get; set; }

        public void OnGet()
        {
            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (Package.DeliveryDate.Date <= DateTime.Now.Date)
            {
                ModelState.AddModelError("Package.DeliveryDate", "Delivery date must be a future date.");
            }

            if (Package.Weight <= 0)
            {
                ModelState.AddModelError("Package.Weight", "Weight must be a positive number.");
            }

            if (ModelState.IsValid)
            {
                Package.Cost = CalculateCost(Package.Type.Value, Package.Weight);

                // Store temporary data to pass into confirmation page
                TempData["Package_CustomerId"] = Package.CustomerId;
                TempData["Package_RecipientName"] = Package.RecipientName;
                TempData["Package_Destination"] = Package.Destination;
                TempData["Package_Type"] = (int)Package.Type;
                TempData["Package_Weight"] = Package.Weight.ToString("R");
                TempData["Package_DeliveryDate"] = Package.DeliveryDate.ToString("o");
                TempData["Package_Cost"] = Package.Cost.ToString("R");

                return RedirectToPage("Confirm");
            }

            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
            return Page();
        }

        private static double CalculateCost(Package.PackageType type, double weight)
        {
            if (type == Package.PackageType.Letter)
            {
                return 3.50 + (weight * 0.50);
            }
            else if (type == Package.PackageType.Parcel)
            {
                return 5.00 + (weight * 2.00);
            }

            throw new Exception("Invalid Package type");
        }
    }
}
