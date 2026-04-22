using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    [Authorize(Roles = "Admin")]
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
            existingEmployee.AssignedRoute = Employee.AssignedRoute;
            existingEmployee.PPS = Employee.PPS;
            existingEmployee.Address = Employee.Address;
            existingEmployee.DateOfBirth = Employee.DateOfBirth;

            _unitOfWork.EmployeeRepo.Update(existingEmployee);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}
