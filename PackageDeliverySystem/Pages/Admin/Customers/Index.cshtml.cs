using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.DataAccess;
using PackageDeliverySystem.Models;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;



namespace PackageDeliverySystem.Pages.Admin.Customers
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            Customers = _unitOfWork.CustomerRepo.GetAllWithPackages();
        }
    }
}
