using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageTracking
{
    public class NumberTrackModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public string OrderNumber { get; set; } = string.Empty;

        public Package? TrackedPackage { get; set; }
        public string? ErrorMessage { get; set; }

        public NumberTrackModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            var allPackages = _unitOfWork.PackageRepo.GetAll();
            var package = allPackages.FirstOrDefault(p => p.OrderNumber == OrderNumber);

            if (package == null)
            {
                ErrorMessage = "No package found with the provided order number.";
            }
            else
            {
                TrackedPackage = package;
            }
        }
    }
}
