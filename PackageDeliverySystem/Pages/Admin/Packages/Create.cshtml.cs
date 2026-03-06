using System;
using System.Linq;
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
            ModelState.Remove("Package.OrderNumber");

            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(Package.OrderNumber))
                {
                    var latest = _unitOfWork.PackageRepo.GetAll()
                                 .OrderByDescending(p => p.Id)
                                 .FirstOrDefault();

                    string newOrderNumber;

                    if (latest == null || string.IsNullOrWhiteSpace(latest.OrderNumber))
                    {
                        newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                    }
                    else
                    {
                        var last = latest.OrderNumber.Trim();
                        var lastDash = last.LastIndexOf('-');

                        if (lastDash >= 0 && lastDash < last.Length - 1)
                        {
                            var prefix = last.Substring(0, lastDash + 1);
                            var numericPart = last.Substring(lastDash + 1);

                            if (int.TryParse(numericPart, out var seq))
                            {
                                var nextSeq = (seq + 1).ToString().PadLeft(numericPart.Length, '0');
                                newOrderNumber = prefix + nextSeq;
                            }
                            else
                            {
                                newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                            }
                        }
                        else
                        {
                            newOrderNumber = $"ORD-{DateTime.Now.Year}-{1.ToString().PadLeft(5, '0')}";
                        }
                    }

                    Package.OrderNumber = newOrderNumber;

                }
                _unitOfWork.PackageRepo.Add(Package);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }

            Customers = new SelectList(_unitOfWork.CustomerRepo.GetAll(), "Id", "Name");
            return Page();
        }
    }
}
