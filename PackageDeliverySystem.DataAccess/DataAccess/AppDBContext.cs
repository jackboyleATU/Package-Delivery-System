using Microsoft.EntityFrameworkCore;
using PackageDeliverySystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDeliverySystem.DataAccess.DataAccess
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(c =>
            {
                c.Property(x => x.Name).IsRequired().HasMaxLength(100);
                c.Property(x => x.Address).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.Property(x => x.Name).IsRequired().HasMaxLength(100);
                e.Property(x => x.PPS).IsRequired().HasMaxLength(20);
                e.Property(x => x.Address).IsRequired().HasMaxLength(200);
                e.Property(x => x.Username).IsRequired().HasMaxLength(50);
                e.Property(x => x.Password).IsRequired().HasMaxLength(100);

                // Useful uniqueness constraints for logins / PPS
                e.HasIndex(x => x.PPS).IsUnique();
                e.HasIndex(x => x.Username).IsUnique();
            });

            modelBuilder.Entity<Package>(p =>
            {
                p.Property(x => x.Destination).IsRequired().HasMaxLength(200);
                p.Property(x => x.RecipientName).IsRequired().HasMaxLength(100);

                p.HasOne(x => x.Customer)
                 .WithMany(c => c.Packages)
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // Employees (2 Drivers, 2 Admin)
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Sean Murphy",
                    Dept = Employee.Department.Driver,
                    PPS = "1234567AB",
                    Address = "12 Oak Drive, Derry",
                    DateOfBirth = new DateTime(1990, 4, 12),
                    Salary = 35000,
                    Username = "driver1",
                    Password = "pass123" 
                },
                new Employee
                {
                    Id = 2,
                    Name = "Conor Kelly",
                    Dept = Employee.Department.Driver,
                    PPS = "2345678BC",
                    Address = "45 Elm Park, Letterkenny",
                    DateOfBirth = new DateTime(1988, 7, 21),
                    Salary = 36000,
                    Username = "driver2",
                    Password = "pass123" 
                },
                new Employee
                {
                    Id = 3,
                    Name = "Patrick Doherty",
                    Dept = Employee.Department.Admin,
                    PPS = "3456789CD",
                    Address = "22 Hillcrest, Dublin",
                    DateOfBirth = new DateTime(1992, 9, 5),
                    Salary = 50000,
                    Username = "admin1",
                    Password = "admin123" 
                },
                new Employee
                {
                    Id = 4,
                    Name = "Ethan Curran",
                    Dept = Employee.Department.Admin,
                    PPS = "4567890DE",
                    Address = "7 Meadow View, Derry",
                    DateOfBirth = new DateTime(1999, 1, 15),
                    Salary = 52000,
                    Username = "admin2",
                    Password = "admin123" 
                }
            );

            // Customers (25)
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Emma OConnor", Address = "12 Hill St, Derry" },
                new Customer { Id = 2, Name = "Sophie Gallagher", Address = "4 Main Rd, Letterkenny" },
                new Customer { Id = 3, Name = "Aoife Kelly", Address = "8 River Walk, Buncrana" },
                new Customer { Id = 4, Name = "Sarah Murphy", Address = "22 Oak Ave, Dublin" },
                new Customer { Id = 5, Name = "Lucy Boyle", Address = "9 Park Lane, Cork" },
                new Customer { Id = 6, Name = "Grace Dunne", Address = "1 Green Rd, Galway" },
                new Customer { Id = 7, Name = "Mia Quinn", Address = "3 Harbour View, Sligo" },
                new Customer { Id = 8, Name = "Hannah Ward", Address = "7 Meadow Rd, Limerick" },
                new Customer { Id = 9, Name = "Chloe Reid", Address = "14 Bridge St, Waterford" },
                new Customer { Id = 10, Name = "Ella Ferry", Address = "6 Hilltop, Donegal" },
                new Customer { Id = 11, Name = "Lily Kane", Address = "18 Pine Rd, Armagh" },
                new Customer { Id = 12, Name = "Zoe Moore", Address = "5 Cedar Ave, Newry" },
                new Customer { Id = 13, Name = "Isla Byrne", Address = "11 Glen St, Dundalk" },
                new Customer { Id = 14, Name = "Freya Sweeney", Address = "20 Church Rd, Kilkenny" },
                new Customer { Id = 15, Name = "Ruby McBride", Address = "2 Oakfield, Clare" },
                new Customer { Id = 16, Name = "Emily Gillen", Address = "17 Riverbank, Mayo" },
                new Customer { Id = 17, Name = "Anna Devlin", Address = "9 Parkview, Wexford" },
                new Customer { Id = 18, Name = "Kate Curran", Address = "13 Main St, Monaghan" },
                new Customer { Id = 19, Name = "Olivia OBrien", Address = "15 Hillcrest, Derry" },
                new Customer { Id = 20, Name = "Ava McLaughlin", Address = "19 Oak Rd, Strabane" },
                new Customer { Id = 21, Name = "Molly Gallagher", Address = "21 Harbour St, Galway" },
                new Customer { Id = 22, Name = "Evie Kelly", Address = "23 Station Rd, Cork" },
                new Customer { Id = 23, Name = "Niamh Murphy", Address = "25 Glen Rd, Dublin" },
                new Customer { Id = 24, Name = "Clara Boyle", Address = "27 Bridge Ave, Sligo" },
                new Customer { Id = 25, Name = "Erin Doherty", Address = "29 Meadow View, Letterkenny" }
            );

            // Packages (35)
            modelBuilder.Entity<Package>().HasData(
                new Package { Id = 1, CustomerId = 1, RecipientName = "Emma OConnor", Destination = "12 Hill St, Derry", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 12.99 },
                new Package { Id = 2, CustomerId = 1, RecipientName = "Emma OConnor", Destination = "12 Hill St, Derry", Type = Package.PackageType.Letter, Status = Package.PackageStatus.InTransit, Cost = 4.99 },
                new Package { Id = 3, CustomerId = 2, RecipientName = "Sophie Gallagher", Destination = "4 Main Rd, Letterkenny", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup, Cost = 18.99 },
                new Package { Id = 4, CustomerId = 2, RecipientName = "Sophie Gallagher", Destination = "4 Main Rd, Letterkenny", Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered, Cost = 4.50 },
                new Package { Id = 5, CustomerId = 3, RecipientName = "Aoife Kelly", Destination = "8 River Walk, Buncrana", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 14.50 },
                new Package { Id = 6, CustomerId = 3, RecipientName = "Aoife Kelly", Destination = "8 River Walk, Buncrana", Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered, Cost = 4.20 },
                new Package { Id = 7, CustomerId = 4, RecipientName = "Sarah Murphy", Destination = "22 Oak Ave, Dublin", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 22.50 },
                new Package { Id = 8, CustomerId = 4, RecipientName = "Sarah Murphy", Destination = "22 Oak Ave, Dublin", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit, Cost = 11.75 },
                new Package { Id = 9, CustomerId = 5, RecipientName = "Lucy Boyle", Destination = "9 Park Lane, Cork", Type = Package.PackageType.Letter, Status = Package.PackageStatus.AwaitingPickup, Cost = 3.99 },
                new Package { Id = 10, CustomerId = 5, RecipientName = "Lucy Boyle", Destination = "9 Park Lane, Cork", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 20.00 },
                new Package { Id = 11, CustomerId = 6, RecipientName = "Grace Dunne", Destination = "1 Green Rd, Galway", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 10.75 },
                new Package { Id = 12, CustomerId = 7, RecipientName = "Mia Quinn", Destination = "3 Harbour View, Sligo", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup, Cost = 19.99 },
                new Package { Id = 13, CustomerId = 8, RecipientName = "Hannah Ward", Destination = "7 Meadow Rd, Limerick", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 11.50 },
                new Package { Id = 14, CustomerId = 9, RecipientName = "Chloe Reid", Destination = "14 Bridge St, Waterford", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 24.99 },
                new Package { Id = 15, CustomerId = 10, RecipientName = "Ella Ferry", Destination = "6 Hilltop, Donegal", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup, Cost = 12.75 },
                new Package { Id = 16, CustomerId = 10, RecipientName = "Ella Ferry", Destination = "6 Hilltop, Donegal", Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered, Cost = 4.10 },
                new Package { Id = 17, CustomerId = 11, RecipientName = "Lily Kane", Destination = "18 Pine Rd, Armagh", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 13.40 },
                new Package { Id = 18, CustomerId = 12, RecipientName = "Zoe Moore", Destination = "5 Cedar Ave, Newry", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit, Cost = 21.00 },
                new Package { Id = 19, CustomerId = 13, RecipientName = "Isla Byrne", Destination = "11 Glen St, Dundalk", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 15.99 },
                new Package { Id = 20, CustomerId = 14, RecipientName = "Freya Sweeney", Destination = "20 Church Rd, Kilkenny", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 23.99 },
                new Package { Id = 21, CustomerId = 15, RecipientName = "Ruby McBride", Destination = "2 Oakfield, Clare", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 8.99 },
                new Package { Id = 22, CustomerId = 16, RecipientName = "Emily Gillen", Destination = "17 Riverbank, Mayo", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup, Cost = 20.99 },
                new Package { Id = 23, CustomerId = 17, RecipientName = "Anna Devlin", Destination = "9 Parkview, Wexford", Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered, Cost = 3.50 },
                new Package { Id = 24, CustomerId = 18, RecipientName = "Kate Curran", Destination = "13 Main St, Monaghan", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit, Cost = 12.49 },
                new Package { Id = 25, CustomerId = 19, RecipientName = "Olivia OBrien", Destination = "15 Hillcrest, Derry", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 19.49 },
                new Package { Id = 26, CustomerId = 20, RecipientName = "Ava McLaughlin", Destination = "19 Oak Rd, Strabane", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 13.99 },
                new Package { Id = 27, CustomerId = 21, RecipientName = "Molly Gallagher", Destination = "21 Harbour St, Galway", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 22.99 },
                new Package { Id = 28, CustomerId = 22, RecipientName = "Evie Kelly", Destination = "23 Station Rd, Cork", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 14.49 },
                new Package { Id = 29, CustomerId = 23, RecipientName = "Niamh Murphy", Destination = "25 Glen Rd, Dublin", Type = Package.PackageType.Letter, Status = Package.PackageStatus.InTransit, Cost = 4.25 },
                new Package { Id = 30, CustomerId = 24, RecipientName = "Clara Boyle", Destination = "27 Bridge Ave, Sligo", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 21.99 },
                new Package { Id = 31, CustomerId = 25, RecipientName = "Erin Doherty", Destination = "29 Meadow View, Letterkenny", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 11.99 },
                new Package { Id = 32, CustomerId = 2, RecipientName = "Sophie Gallagher", Destination = "4 Main Rd, Letterkenny", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 9.99 },
                new Package { Id = 33, CustomerId = 5, RecipientName = "Lucy Boyle", Destination = "9 Park Lane, Cork", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 9.99 },
                new Package { Id = 34, CustomerId = 10, RecipientName = "Ella Ferry", Destination = "6 Hilltop, Donegal", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered, Cost = 19.50 },
                new Package { Id = 35, CustomerId = 15, RecipientName = "Ruby McBride", Destination = "2 Oakfield, Clare", Type = Package.PackageType.Letter, Status = Package.PackageStatus.AwaitingPickup, Cost = 3.75 }
            );
        }
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
