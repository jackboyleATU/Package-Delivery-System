using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Employees
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Employee Employee { get; set; }
        public void OnGet(int id)
        {
            Employee = _unitOfWork.EmployeeRepo.Get(id);
        }

        public IActionResult OnPost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepo.Update(employee);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
