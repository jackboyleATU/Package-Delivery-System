using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.PageViewModels;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Customers
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Register Register { get; set; }

        public CreateModel(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                UserName = Register.EmailAddress,
                Email = Register.EmailAddress,
                FullName = $"{Register.FirstName} {Register.LastName}"
            };

            var result = await _userManager.CreateAsync(user, Register.Password);

            if (result.Succeeded)
            {
                var customer = new Customer
                {
                    Name = $"{Register.FirstName} {Register.LastName}",
                    Email = Register.EmailAddress,
                    PhoneNumber = Register.PhoneNumber,
                    Address = Register.Address
                };

                _unitOfWork.CustomerRepo.Add(customer);
                _unitOfWork.Save();

                user.CustomerId = customer.Id;
                await _userManager.UpdateAsync(user);
                await _userManager.AddToRoleAsync(user, "Customer");

                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}
