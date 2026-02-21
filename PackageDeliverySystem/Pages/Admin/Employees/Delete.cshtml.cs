using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        
        public void OnGet(int id)
        {
            Employee = _unitOfWork.EmployeeRepo.Get(id);
        }

        public IActionResult OnPost()
        {
            if (Employee?.Id > 0)
            {
                var employeeToDelete = _unitOfWork.EmployeeRepo.Get(Employee.Id);
                if (employeeToDelete != null)
                {
                    _unitOfWork.EmployeeRepo.Delete(employeeToDelete);
                    _unitOfWork.Save();
                }
            }
            return RedirectToPage("Index");
        }
    }
}
