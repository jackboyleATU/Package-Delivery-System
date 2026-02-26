using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.Models.Models
{
    public class Package
    {
        public enum PackageStatus
        {
            AwaitingPickup,
            InTransit,
            Delivered
        }

        public enum PackageType { Letter, Parcel }

        [Key]
        public int Id { get; set; }

        public PackageStatus Status { get; set; }

        public string Destination { get; set; }

        public string RecipientName { get; set; }

        public PackageType Type { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double Weight { get; set; }

        [Range(0, 4)]
        public int AttemptedDeliveries { get; set; }

        public double Cost { get; set; }

        public int CustomerId { get; set; } 
        public Customer? Customer { get; set; }

    }
}
