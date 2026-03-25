using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.CustomerViews.PackageSendPages;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages
{
    [Authorize(Roles = "Customer,Driver,Admin")]
    public class profileDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public Customer? customer;
        public Employee? employee;

        public IEnumerable<Package> packagesToBeDelivered = null;
        public IEnumerable<Employee> employeeCount = null;
        public IEnumerable<Customer> customerCount = null;

        public profileDetailsModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            employeeCount = _unitOfWork.EmployeeRepo.GetAll();
            customerCount = _unitOfWork.CustomerRepo.GetAll();
            packagesToBeDelivered = _unitOfWork.PackageRepo.GetAll()
                .Where(p => p.Status == Package.PackageStatus.AwaitingPickup)
                .ToList();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return;

            // Check if user is a Customer
            if (currentUser.CustomerId.HasValue)
            {
                customer = _unitOfWork.CustomerRepo.Get(currentUser.CustomerId.Value);
                
                // Manually load packages if not already loaded
                if (customer != null && (customer.Packages == null || !customer.Packages.Any()))
                {
                    customer.Packages = _unitOfWork.PackageRepo.GetAll()
                        .Where(p => p.CustomerId == customer.Id)
                        .ToList();
                }
            }
            // Check if user is an Employee (Driver/Admin)
            else if (currentUser.EmployeeId.HasValue)
            {
                employee = _unitOfWork.EmployeeRepo.Get(currentUser.EmployeeId.Value);
            }
        }
    }
}
