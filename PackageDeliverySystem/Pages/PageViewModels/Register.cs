using System.ComponentModel.DataAnnotations;

namespace PackageDeliverySystem.Pages.PageViewModels
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords Do Not Match")]
        public string ConfirmPassword { get; set; }

    }
}
