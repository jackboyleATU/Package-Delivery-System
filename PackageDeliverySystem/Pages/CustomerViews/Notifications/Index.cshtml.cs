using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.CustomerViews.Notifications
{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public IEnumerable<CustomerEmail> Emails { get; set; } = new List<CustomerEmail>();

        public IndexModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser?.CustomerId != null)
            {
                Emails = _unitOfWork.CustomerEmailRepo.GetEmailsByCustomer(currentUser.CustomerId.Value);
            }
        }
    }
}
