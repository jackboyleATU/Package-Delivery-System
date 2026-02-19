using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Packages
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Package package { get; set; }
        public void OnGet(int id)
        {
            package = _unitOfWork.PackageRepo.Get(id);
        }

        public IActionResult OnPost(Package package)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PackageRepo.Update(package);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
