using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageSendPages
{
    [Authorize(Roles = "Customer")]
    public class PackageSendModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public PackageSendModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public Package Package { get; set; } = new Package();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user?.CustomerId != null)
            {
                Package = new Package { CustomerId = user.CustomerId.Value };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user?.CustomerId == null)
            {
                return Unauthorized();
            }

            Package.CustomerId = user.CustomerId.Value;
            ModelState.Remove("Package.CustomerId");

            if (Package.DeliveryDate.Date <= DateTime.Now.Date)
            {
                ModelState.AddModelError("Package.DeliveryDate", "Delivery date must be a future date.");
            }

            if (Package.Weight <= 0)
            {
                ModelState.AddModelError("Package.Weight", "Weight must be a positive number.");
            }

            // Ensure user selected a package type (Type is nullable on the model)
            if (Package.Type == null)
            {
                ModelState.AddModelError("Package.Type", "Please select a package type.");
            }

            if (ModelState.IsValid)
            {
                // Package.Type is validated non-null above, use .Value to pass non-nullable enum
                Package.Cost = CalculateCost(Package.Type.Value, Package.Weight);

                TempData["Package_CustomerId"] = Package.CustomerId;
                TempData["Package_RecipientName"] = Package.RecipientName;
                TempData["Package_Destination"] = Package.Destination;
                TempData["Package_Type"] = (int)Package.Type.Value;
                TempData["Package_Weight"] = Package.Weight.ToString("R");
                TempData["Package_DeliveryDate"] = Package.DeliveryDate.ToString("o");
                TempData["Package_Cost"] = Package.Cost.ToString("R");

                return RedirectToPage("Confirm");
            }

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
