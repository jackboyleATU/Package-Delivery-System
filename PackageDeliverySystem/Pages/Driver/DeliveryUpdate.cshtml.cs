using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Services;

namespace PackageDeliverySystem.Pages.Driver
{
    public class DeliveryUpdateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryUpdateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Package Package { get; set; }

        public SelectList Customers { get; set; }

        public void OnGet(int id)
        {
            Package = _unitOfWork.PackageRepo.Get(id);
            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
                return Page();
            }

            var packageFromDb = _unitOfWork.PackageRepo.Get(Package.Id);
            if (packageFromDb == null)
            {
                return NotFound();
            }

            packageFromDb.OrderNumber = Package.OrderNumber;
            packageFromDb.Status = Package.Status;
            packageFromDb.Destination = Package.Destination;
            packageFromDb.RecipientName = Package.RecipientName;
            packageFromDb.Type = Package.Type;
            packageFromDb.DeliveryDate = Package.DeliveryDate;
            packageFromDb.Weight = Package.Weight;
            packageFromDb.AttemptedDeliveries = Package.AttemptedDeliveries;
            packageFromDb.Cost = Package.Cost;
            packageFromDb.CustomerId = Package.CustomerId;

            if (packageFromDb.AttemptedDeliveries >= 3)
            {
                packageFromDb.Status = Package.PackageStatus.ReturnedToSender;

                var customer = _unitOfWork.CustomerRepo.Get(packageFromDb.CustomerId);

                if (customer != null)
                {
                    var email = new CustomerEmail
                    {
                        CustomerId = customer.Id,
                        PackageId = packageFromDb.Id,
                        Subject = $"Returned to Sender - {packageFromDb.OrderNumber}",
                        Body =
$@"Dear {customer.Name},

Your package has been returned to sender because 3 or more delivery attempts were unsuccessful.

Package Details:
Order Number: {packageFromDb.OrderNumber}
Recipient Name: {packageFromDb.RecipientName}
Destination: {packageFromDb.Destination}
Package Type: {packageFromDb.Type}
Delivery Date: {packageFromDb.DeliveryDate:dd/MM/yyyy}
Weight: {packageFromDb.Weight} kg
Cost: €{packageFromDb.Cost:F2}
Attempted Deliveries: {packageFromDb.AttemptedDeliveries}
Current Status: {packageFromDb.Status}

Please contact support if you need any further help.

Regards,
LK Post"
                    };

                    _unitOfWork.CustomerEmailRepo.Add(email);
                }
            }

            _unitOfWork.PackageRepo.Update(packageFromDb);
            _unitOfWork.Save();

            return RedirectToPage("DeliveryList");
        }
    }
}