using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Returns
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Package> ReturnPackages { get; set; } = Enumerable.Empty<Package>();

        [TempData]
        public string? FlashMessage { get; set; }

        public void OnGet()
        {
            ReturnPackages = _unitOfWork.PackageRepo
                .GetAllWithCustomer()
                .Where(p => p.AttemptedDeliveries >= 3)
                .OrderByDescending(p => p.AttemptedDeliveries)
                .ThenBy(p => p.Id)
                .ToList();
        }

        public IActionResult OnPostReturnToSender(int id)
        {
            var pkg = _unitOfWork.PackageRepo.GetAllWithCustomer().FirstOrDefault(p => p.Id == id);
            if (pkg == null)
            {
                FlashMessage = "Package not found.";
                return RedirectToPage();
            }

            if (pkg.AttemptedDeliveries < 3)
            {
                FlashMessage = "This package is not eligible for return yet (needs 3+ attempted deliveries).";
                return RedirectToPage();
            }

            if (pkg.Customer == null)
            {
                FlashMessage = "Cannot return to sender because the sender (Customer) record is missing.";
                return RedirectToPage();
            }

            // Update the package to go back to sender (customer)
            pkg.RecipientName = pkg.Customer.Name;
            pkg.Destination = pkg.Customer.Address;

            // Choose a status that exists in your enum
            // You currently have: AwaitingPickup, InTransit, Delivered
            pkg.Status = Package.PackageStatus.InTransit;

            // Reset attempts so it doesn’t instantly re-appear in Returns
            pkg.AttemptedDeliveries = 0;

            // `pkg` was loaded from the same DbContext and is already tracked.
            // Modifying its properties is sufficient — calling Save() will persist changes.
            _unitOfWork.Save();

            FlashMessage = $"Package has been set to RETURN TO SENDER. It will be sent back to: {pkg.Customer.Name}, {pkg.Customer.Address}.";
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var pkg = _unitOfWork.PackageRepo.Get(id);
            if (pkg == null)
            {
                FlashMessage = "Package not found.";
                return RedirectToPage();
            }

            _unitOfWork.PackageRepo.Delete(pkg);
            _unitOfWork.Save();

            FlashMessage = "Package deleted from the system.";
            return RedirectToPage();
        }
    }
}