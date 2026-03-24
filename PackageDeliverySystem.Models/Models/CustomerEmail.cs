using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackageDeliverySystem.Models.Models
{
    public class CustomerEmail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        [Required]
        public int PackageId { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Package? Package { get; set; }

        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}
