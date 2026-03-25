using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Employee Employee { get; set; }
        public string Password { get; set; }

        public EditModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingEmployee = _unitOfWork.EmployeeRepo.Get(Employee.Id);
            if (existingEmployee == null)
                return NotFound();

            // Update employee record
            existingEmployee.Name = Employee.Name;
            existingEmployee.Username = Employee.Username;
            existingEmployee.Dept = Employee.Dept;
            existingEmployee.Salary = Employee.Salary;

            _unitOfWork.EmployeeRepo.Update(existingEmployee);
            _unitOfWork.Save();

            // Find and update the associated ApplicationUser
            var applicationUser = await _userManager.FindByIdAsync(existingEmployee.Id.ToString());
            if (applicationUser != null)
            {
                applicationUser.UserName = Employee.Username;
                applicationUser.FullName = Employee.Name;

                var result = await _userManager.UpdateAsync(applicationUser);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }

                // Update password if provided
                if (!string.IsNullOrEmpty(Password))
                {
                    var removePasswordResult = await _userManager.RemovePasswordAsync(applicationUser);
                    if (!removePasswordResult.Succeeded)
                    {
                        foreach (var error in removePasswordResult.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }

                    var addPasswordResult = await _userManager.AddPasswordAsync(applicationUser, Password);
                    if (!addPasswordResult.Succeeded)
                    {
                        foreach (var error in addPasswordResult.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }
                }
            }

            return RedirectToPage("Index");
        }
    }
}
