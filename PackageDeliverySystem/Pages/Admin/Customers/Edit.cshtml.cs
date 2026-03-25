using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Customers
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Customer Customer { get; set; }

        public EditModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingCustomer = _unitOfWork.CustomerRepo.Get(Customer.Id);
            if (existingCustomer == null)
                return NotFound();

            // Update customer record
            existingCustomer.Name = Customer.Name;
            existingCustomer.Email = Customer.Email;
            existingCustomer.PhoneNumber = Customer.PhoneNumber;
            existingCustomer.Address = Customer.Address;

            _unitOfWork.CustomerRepo.Update(existingCustomer);
            _unitOfWork.Save();

            // Find and update the associated ApplicationUser
            var applicationUser = await _userManager.FindByEmailAsync(existingCustomer.Email);
            if (applicationUser != null)
            {
                applicationUser.Email = Customer.Email;
                applicationUser.UserName = Customer.Email;
                applicationUser.FullName = Customer.Name;

                var result = await _userManager.UpdateAsync(applicationUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }

            return RedirectToPage("Index");
        }
    }
}
