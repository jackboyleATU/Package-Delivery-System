using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageTracking
{
    [Authorize(Roles="Customer")]
    public class AccountTrackModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Package> Packages { get; set; }

        [BindProperty]
        public string OrderNumber { get; set; } = string.Empty;

        public AccountTrackModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            var userManager = HttpContext.RequestServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
            var currentUser = userManager?.FindByNameAsync(User.Identity?.Name).Result;
            
            if (currentUser?.CustomerId > 0)
            {
                Packages = _unitOfWork.PackageRepo.GetPackagesByCustomer((int)currentUser.CustomerId);
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(OrderNumber))
            {
                ModelState.AddModelError("OrderNumber", "Please enter an order number.");
                return Page();
            }

            TempData["TrackingNumber"] = OrderNumber;
            return RedirectToPage("NumberTrack", new { orderNumber = OrderNumber });
        }
    }
}
