using System.ComponentModel.DataAnnotations;

namespace PackageDeliverySystem.Pages.PageViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
