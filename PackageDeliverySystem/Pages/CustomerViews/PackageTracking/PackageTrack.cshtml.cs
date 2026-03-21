using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PackageDeliverySystem.Pages.CustomerViews.PackageTracking
{
    public class PackageTrackModel : PageModel
    {
        [BindProperty]
        public string OrderNumber { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPostNumber() 
        {
            if (string.IsNullOrWhiteSpace(OrderNumber))
            {
                ModelState.AddModelError("OrderNumber", "Please enter an order number.");
                return Page();
            }

            TempData["TrackingNumber"] = OrderNumber;
            return RedirectToPage("NumberTrack", new { orderNumber = OrderNumber });
        }

        public IActionResult OnPostAccount()
        {
            return RedirectToPage("AccountTrack");
        }
    }
}
