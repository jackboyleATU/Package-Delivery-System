using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Employee Employee { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _unitOfWork.EmployeeRepo.Get(id);
            if (Employee == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.Get(id);
            if (employee == null)
                return NotFound();

            // Find and delete the associated ApplicationUser
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
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

            // Delete the employee record
            _unitOfWork.EmployeeRepo.Delete(employee);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}
