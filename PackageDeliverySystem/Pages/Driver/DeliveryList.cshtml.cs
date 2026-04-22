using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;
using System.Diagnostics;

namespace PackageDeliverySystem.Pages.Driver
{
    [Authorize(Roles = "Driver")]
    public class DeliveryListModel : PageModel
    {
        public IEnumerable<Package> UnsortedPackages { get; set; } = new List<Package>();
        public IEnumerable<Package> Packages { get; set; } = new List<Package>();

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeliveryListModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public void OnGet()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            Debug.WriteLine($"Current User: {currentUser?.UserName}, EmployeeId: {currentUser?.EmployeeId}");
            
            if (currentUser == null)
            {
                Debug.WriteLine("Current user is null");
                return;
            }

            UnsortedPackages = _unitOfWork.PackageRepo.GetAllUnreturned() ?? new List<Package>();
            Debug.WriteLine($"Unreturned packages count: {UnsortedPackages.Count()}");

            foreach (var pkg in UnsortedPackages)
            {
                Debug.WriteLine($"  Package: {pkg.Id}, Route: {pkg.Route}, Status: {pkg.Status}");
            }

            var employee = _unitOfWork.EmployeeRepo?.Get(currentUser.EmployeeId ?? 0);
            Debug.WriteLine($"Employee: {employee?.Name}, AssignedRoute: {employee?.AssignedRoute}");
            
            if (employee == null)
            {
                Debug.WriteLine("Employee is null");
                return;
            }

            var assignedRoute = employee.AssignedRoute.ToString();
            Debug.WriteLine($"Assigned Route String: {assignedRoute}");
            
            var packageList = new List<Package>();
            
            foreach (var package in UnsortedPackages)
            {
                var packageRoute = package.Route?.ToString();
                Debug.WriteLine($"  Comparing: {packageRoute} == {assignedRoute} ? {packageRoute == assignedRoute}");
                
                if (packageRoute == assignedRoute)
                {
                    packageList.Add(package);
                }
            }
            
            Debug.WriteLine($"Matching packages count: {packageList.Count}");
            Packages = packageList;
        }
    }
}
