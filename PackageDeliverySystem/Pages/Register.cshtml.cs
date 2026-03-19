using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.PageViewModels;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public Register Register { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Register.EmailAddress,
                    Email = Register.EmailAddress,
                    FullName = $"{Register.FirstName} {Register.LastName}"
                };

                var result = await _userManager.CreateAsync(user, Register.Password);

                if (result.Succeeded)
                {
                    // Create a corresponding Customer record
                    var customer = new Customer
                    {
                        Name = $"{Register.FirstName} {Register.LastName}",
                        Email = Register.EmailAddress,
                        PhoneNumber = Register.PhoneNumber,
                        Address = string.Empty
                    };

                    _unitOfWork.CustomerRepo.Add(customer);
                    _unitOfWork.Save();

                    // Link the ApplicationUser to the Customer
                    user.CustomerId = customer.Id;
                    await _userManager.UpdateAsync(user);

                    // Add to Customer role
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(String.Empty, error.Description);
            }
            return Page();
        }
    }
}
