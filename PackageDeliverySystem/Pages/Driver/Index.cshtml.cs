using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PackageDeliverySystem.Models.Models;

namespace PackageDeliverySystem.Pages.Driver
{
    public class IndexModel : PageModel
    {

        public Employee Employee { get; set; }
        public void OnGet()
        {
        }
    }
}
