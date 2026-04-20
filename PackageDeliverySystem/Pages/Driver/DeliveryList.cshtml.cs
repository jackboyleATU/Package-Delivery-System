using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Driver
{
    public class DeliveryListModel : PageModel
    {
        public IEnumerable<Package> Packages { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public DeliveryListModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            Packages = _unitOfWork.PackageRepo.GetAllUnreturned();
        }
    }
}
