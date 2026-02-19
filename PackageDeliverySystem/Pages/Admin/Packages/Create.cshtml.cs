using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public Package package { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Package package)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PackageRepo.Add(package);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}
