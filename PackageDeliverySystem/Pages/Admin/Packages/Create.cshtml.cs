using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Packages
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Package Package { get; set; }
        
        public SelectList Customers { get; set; }
        
        public void OnGet()
        {
            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PackageRepo.Add(Package);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            
            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
            return Page();
        }
    }
}
