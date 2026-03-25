using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.CustomerViews.Notifications
{
    [Authorize(Roles = "Customer")]
    public class ViewModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerEmail? Email { get; set; }

        public ViewModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser?.CustomerId == null)
            {
                return RedirectToPage("/Login");
            }

            Email = _unitOfWork.CustomerEmailRepo.GetEmailWithDetails(id);

            if (Email == null || Email.CustomerId != currentUser.CustomerId.Value)
            {
                return NotFound();
            }

            if (!Email.IsRead)
            {
                Email.IsRead = true;
                _unitOfWork.CustomerEmailRepo.Update(Email);
                _unitOfWork.Save();
            }

            return Page();
        }
    }
}
