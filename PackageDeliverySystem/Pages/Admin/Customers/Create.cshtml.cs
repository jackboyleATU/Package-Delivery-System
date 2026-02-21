using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Customers
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Customer { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerRepo.Add(customer);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}
