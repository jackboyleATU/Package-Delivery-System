using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.Models.Models
{
    public class Employee
    {
        public enum Department { Driver, Admin };

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Department Dept { get; set; }

        public string PPS { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public double Salary { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }
    }
}
