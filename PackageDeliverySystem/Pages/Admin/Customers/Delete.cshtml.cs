using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Customer { get; set; }
        public void OnGet(int id)
        {
            Customer = _unitOfWork.CustomerRepo.Get(id);
        }

        public IActionResult OnPost(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerRepo.Delete(customer);
                _unitOfWork.Save();

            }
            return RedirectToPage("Index");
        }
    }
}
