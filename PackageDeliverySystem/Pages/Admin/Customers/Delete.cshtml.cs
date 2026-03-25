using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Customers
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Customer Customer { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            Customer = _unitOfWork.CustomerRepo.Get(id);
            if (Customer == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var customer = _unitOfWork.CustomerRepo.Get(id);
            if (customer == null)
                return NotFound();

            // Find and delete the associated ApplicationUser
            var applicationUser = await _userManager.FindByEmailAsync(customer.Email);
            if (applicationUser != null)
            {
                var result = await _userManager.DeleteAsync(applicationUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }

            // Delete the customer record
            _unitOfWork.CustomerRepo.Delete(customer);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}
