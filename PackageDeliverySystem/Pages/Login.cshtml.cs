using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.PageViewModels;

namespace PackageDeliverySystem.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public Login Login { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Login.EmailAddress, Login.Password, Login.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect");
                    return Page();
                }
            }

            return RedirectToPage("Index");
        }
    }
}
