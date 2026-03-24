using System;
using System.ComponentModel.DataAnnotations;

namespace PackageDeliverySystem.Models.Models
{
    public class Package
    {
        public enum PackageStatus
        {
            Processing,
            AwaitingPickup,
            InTransit,
            Delivered,
            ReturnedToSender
        }

        public enum PackageType { Letter, Parcel }

        [Key]
        public int Id { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public PackageStatus Status { get; set; }

        public string Destination { get; set; }

        public string RecipientName { get; set; }

        // Make Type nullable so the form can start with the placeholder selected.
        [Required(ErrorMessage = "Please select a package type.")]
        public PackageType? Type { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double Weight { get; set; }

        [Range(0, 4)]
        public int AttemptedDeliveries { get; set; }

        public double Cost { get; set; }
        // Require a valid customer selection (IDs start at 1)
        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
