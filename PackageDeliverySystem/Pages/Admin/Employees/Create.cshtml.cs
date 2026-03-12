using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Save the Employee record first to get its Id
            _unitOfWork.EmployeeRepo.Add(Employee);
            _unitOfWork.Save();

            // Determine the Identity role from the Department enum
            var role = Employee.Dept == Employee.Department.Admin ? "Admin" : "Driver";

            // Create the linked Identity account
            var appUser = new ApplicationUser
            {
                UserName = Employee.Username + "@gmail.ie",
                Email = Employee.Username + "@gmail.ie",
                EmailConfirmed = true,
                FullName = Employee.Name,
                EmployeeId = Employee.Id
            };

            var result = await _userManager.CreateAsync(appUser, Employee.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, role);
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
