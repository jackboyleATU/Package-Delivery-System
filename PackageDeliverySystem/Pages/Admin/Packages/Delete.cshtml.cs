using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Admin.Packages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Package Package { get; set; }
        
        public void OnGet(int id)
        {
            Package = _unitOfWork.PackageRepo.Get(id);
        }

        public IActionResult OnPost()
        {
            if (Package?.Id > 0)
            {
                var packageToDelete = _unitOfWork.PackageRepo.Get(Package.Id);
                if (packageToDelete != null)
                {
                    _unitOfWork.PackageRepo.Delete(packageToDelete);
                    _unitOfWork.Save();
                }
            }
            return RedirectToPage("Index");
        }
    }
}
