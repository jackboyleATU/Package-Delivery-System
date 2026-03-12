using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class AppDBContext : IdentityDbContext<ApplicationUser>
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
                p.Property(x => x.OrderNumber).IsRequired().HasMaxLength(20);

                p.HasOne(x => x.Customer)
                 .WithMany(c => c.Packages)
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ApplicationUser -> Employee / Customer relationships
            modelBuilder.Entity<ApplicationUser>(u =>
            {
                u.HasOne(x => x.Employee)
                 .WithMany()
                 .HasForeignKey(x => x.EmployeeId)
                 .OnDelete(DeleteBehavior.SetNull);

                u.HasOne(x => x.Customer)
                 .WithMany()
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.SetNull);
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
                new Customer { Id = 1,  Name = "Emma OConnor",     Address = "12 Hill St, Derry",              PhoneNumber = "0871234501", Email = "emma.oconnor@email.com" },
                new Customer { Id = 2,  Name = "Sophie Gallagher", Address = "4 Main Rd, Letterkenny",         PhoneNumber = "0871234502", Email = "sophie.gallagher@email.com" },
                new Customer { Id = 3,  Name = "Aoife Kelly",      Address = "8 River Walk, Buncrana",         PhoneNumber = "0871234503", Email = "aoife.kelly@email.com" },
                new Customer { Id = 4,  Name = "Sarah Murphy",     Address = "22 Oak Ave, Dublin",             PhoneNumber = "0871234504", Email = "sarah.murphy@email.com" },
                new Customer { Id = 5,  Name = "Lucy Boyle",       Address = "9 Park Lane, Cork",              PhoneNumber = "0871234505", Email = "lucy.boyle@email.com" },
                new Customer { Id = 6,  Name = "Grace Dunne",      Address = "1 Green Rd, Galway",             PhoneNumber = "0871234506", Email = "grace.dunne@email.com" },
                new Customer { Id = 7,  Name = "Mia Quinn",        Address = "3 Harbour View, Sligo",          PhoneNumber = "0871234507", Email = "mia.quinn@email.com" },
                new Customer { Id = 8,  Name = "Hannah Ward",      Address = "7 Meadow Rd, Limerick",          PhoneNumber = "0871234508", Email = "hannah.ward@email.com" },
                new Customer { Id = 9,  Name = "Chloe Reid",       Address = "14 Bridge St, Waterford",        PhoneNumber = "0871234509", Email = "chloe.reid@email.com" },
                new Customer { Id = 10, Name = "Ella Ferry",       Address = "6 Hilltop, Donegal",             PhoneNumber = "0871234510", Email = "ella.ferry@email.com" },
                new Customer { Id = 11, Name = "Lily Kane",        Address = "18 Pine Rd, Armagh",             PhoneNumber = "0871234511", Email = "lily.kane@email.com" },
                new Customer { Id = 12, Name = "Zoe Moore",        Address = "5 Cedar Ave, Newry",             PhoneNumber = "0871234512", Email = "zoe.moore@email.com" },
                new Customer { Id = 13, Name = "Isla Byrne",       Address = "11 Glen St, Dundalk",            PhoneNumber = "0871234513", Email = "isla.byrne@email.com" },
                new Customer { Id = 14, Name = "Freya Sweeney",    Address = "20 Church Rd, Kilkenny",         PhoneNumber = "0871234514", Email = "freya.sweeney@email.com" },
                new Customer { Id = 15, Name = "Ruby McBride",     Address = "2 Oakfield, Clare",              PhoneNumber = "0871234515", Email = "ruby.mcbride@email.com" },
                new Customer { Id = 16, Name = "Emily Gillen",     Address = "17 Riverbank, Mayo",             PhoneNumber = "0871234516", Email = "emily.gillen@email.com" },
                new Customer { Id = 17, Name = "Anna Devlin",      Address = "9 Parkview, Wexford",            PhoneNumber = "0871234517", Email = "anna.devlin@email.com" },
                new Customer { Id = 18, Name = "Kate Curran",      Address = "13 Main St, Monaghan",           PhoneNumber = "0871234518", Email = "kate.curran@email.com" },
                new Customer { Id = 19, Name = "Olivia OBrien",    Address = "15 Hillcrest, Derry",            PhoneNumber = "0871234519", Email = "olivia.obrien@email.com" },
                new Customer { Id = 20, Name = "Ava McLaughlin",   Address = "19 Oak Rd, Strabane",            PhoneNumber = "0871234520", Email = "ava.mclaughlin@email.com" },
                new Customer { Id = 21, Name = "Molly Gallagher",  Address = "21 Harbour St, Galway",          PhoneNumber = "0871234521", Email = "molly.gallagher@email.com" },
                new Customer { Id = 22, Name = "Evie Kelly",       Address = "23 Station Rd, Cork",            PhoneNumber = "0871234522", Email = "evie.kelly@email.com" },
                new Customer { Id = 23, Name = "Niamh Murphy",     Address = "25 Glen Rd, Dublin",             PhoneNumber = "0871234523", Email = "niamh.murphy@email.com" },
                new Customer { Id = 24, Name = "Clara Boyle",      Address = "27 Bridge Ave, Sligo",           PhoneNumber = "0871234524", Email = "clara.boyle@email.com" },
                new Customer { Id = 25, Name = "Erin Doherty",     Address = "29 Meadow View, Letterkenny",    PhoneNumber = "0871234525", Email = "erin.doherty@email.com" }
            );

            // Packages (35)
            modelBuilder.Entity<Package>().HasData(
                new Package { Id = 1,  OrderNumber = "ORD-2025-00001", CustomerId = 1,  RecipientName = "Emma OConnor",     Destination = "12 Hill St, Derry",           Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 5),    Weight = 2.5, AttemptedDeliveries = 0, Cost = 12.99 },
                new Package { Id = 2,  OrderNumber = "ORD-2025-00002", CustomerId = 1,  RecipientName = "Emma OConnor",     Destination = "12 Hill St, Derry",           Type = Package.PackageType.Letter, Status = Package.PackageStatus.InTransit,       DeliveryDate = new DateTime(2025, 1, 8),    Weight = 0.1, AttemptedDeliveries = 0, Cost = 4.99 },
                new Package { Id = 3,  OrderNumber = "ORD-2025-00003", CustomerId = 2,  RecipientName = "Sophie Gallagher", Destination = "4 Main Rd, Letterkenny",      Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 1, 10),   Weight = 3.2, AttemptedDeliveries = 0, Cost = 18.99 },
                new Package { Id = 4,  OrderNumber = "ORD-2025-00004", CustomerId = 2,  RecipientName = "Sophie Gallagher", Destination = "4 Main Rd, Letterkenny",      Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 12),   Weight = 0.1, AttemptedDeliveries = 0, Cost = 4.50 },
                new Package { Id = 5,  OrderNumber = "ORD-2025-00005", CustomerId = 3,  RecipientName = "Aoife Kelly",      Destination = "8 River Walk, Buncrana",      Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 14),   Weight = 1.8, AttemptedDeliveries = 0, Cost = 14.50 },
                new Package { Id = 6,  OrderNumber = "ORD-2025-00006", CustomerId = 3,  RecipientName = "Aoife Kelly",      Destination = "8 River Walk, Buncrana",      Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 15),   Weight = 0.1, AttemptedDeliveries = 0, Cost = 4.20 },
                new Package { Id = 7,  OrderNumber = "ORD-2025-00007", CustomerId = 4,  RecipientName = "Sarah Murphy",     Destination = "22 Oak Ave, Dublin",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 17),   Weight = 4.0, AttemptedDeliveries = 0, Cost = 22.50 },
                new Package { Id = 8,  OrderNumber = "ORD-2025-00008", CustomerId = 4,  RecipientName = "Sarah Murphy",     Destination = "22 Oak Ave, Dublin",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit,       DeliveryDate = new DateTime(2025, 1, 20),   Weight = 2.1, AttemptedDeliveries = 3, Cost = 11.75 },
                new Package { Id = 9,  OrderNumber = "ORD-2025-00009", CustomerId = 5,  RecipientName = "Lucy Boyle",       Destination = "9 Park Lane, Cork",           Type = Package.PackageType.Letter, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 1, 22),   Weight = 0.1, AttemptedDeliveries = 0, Cost = 3.99 },
                new Package { Id = 10, OrderNumber = "ORD-2025-00010", CustomerId = 5,  RecipientName = "Lucy Boyle",       Destination = "9 Park Lane, Cork",           Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 24),   Weight = 3.5, AttemptedDeliveries = 0, Cost = 20.00 },
                new Package { Id = 11, OrderNumber = "ORD-2025-00011", CustomerId = 6,  RecipientName = "Grace Dunne",      Destination = "1 Green Rd, Galway",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 1, 26),   Weight = 1.9, AttemptedDeliveries = 0, Cost = 10.75 },
                new Package { Id = 12, OrderNumber = "ORD-2025-00012", CustomerId = 7,  RecipientName = "Mia Quinn",        Destination = "3 Harbour View, Sligo",       Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 1, 28),   Weight = 3.3, AttemptedDeliveries = 0, Cost = 19.99 },
                new Package { Id = 13, OrderNumber = "ORD-2025-00013", CustomerId = 8,  RecipientName = "Hannah Ward",      Destination = "7 Meadow Rd, Limerick",       Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 1),    Weight = 2.0, AttemptedDeliveries = 0, Cost = 11.50 },
                new Package { Id = 14, OrderNumber = "ORD-2025-00014", CustomerId = 9,  RecipientName = "Chloe Reid",       Destination = "14 Bridge St, Waterford",     Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 3),    Weight = 4.5, AttemptedDeliveries = 0, Cost = 24.99 },
                new Package { Id = 15, OrderNumber = "ORD-2025-00015", CustomerId = 10, RecipientName = "Ella Ferry",       Destination = "6 Hilltop, Donegal",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 2, 5),    Weight = 2.3, AttemptedDeliveries = 0, Cost = 12.75 },
                new Package { Id = 16, OrderNumber = "ORD-2025-00016", CustomerId = 10, RecipientName = "Ella Ferry",       Destination = "6 Hilltop, Donegal",          Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 6),    Weight = 0.1, AttemptedDeliveries = 0, Cost = 4.10 },
                new Package { Id = 17, OrderNumber = "ORD-2025-00017", CustomerId = 11, RecipientName = "Lily Kane",        Destination = "18 Pine Rd, Armagh",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 8),    Weight = 2.4, AttemptedDeliveries = 0, Cost = 13.40 },
                new Package { Id = 18, OrderNumber = "ORD-2025-00018", CustomerId = 12, RecipientName = "Zoe Moore",        Destination = "5 Cedar Ave, Newry",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit,       DeliveryDate = new DateTime(2025, 2, 10),   Weight = 3.8, AttemptedDeliveries = 3, Cost = 21.00 },
                new Package { Id = 19, OrderNumber = "ORD-2025-00019", CustomerId = 13, RecipientName = "Isla Byrne",       Destination = "11 Glen St, Dundalk",         Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 12),   Weight = 2.7, AttemptedDeliveries = 0, Cost = 15.99 },
                new Package { Id = 20, OrderNumber = "ORD-2025-00020", CustomerId = 14, RecipientName = "Freya Sweeney",    Destination = "20 Church Rd, Kilkenny",      Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 14),   Weight = 4.2, AttemptedDeliveries = 0, Cost = 23.99 },
                new Package { Id = 21, OrderNumber = "ORD-2025-00021", CustomerId = 15, RecipientName = "Ruby McBride",     Destination = "2 Oakfield, Clare",           Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 16),   Weight = 1.5, AttemptedDeliveries = 0, Cost = 8.99 },
                new Package { Id = 22, OrderNumber = "ORD-2025-00022", CustomerId = 16, RecipientName = "Emily Gillen",     Destination = "17 Riverbank, Mayo",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 2, 18),   Weight = 3.7, AttemptedDeliveries = 0, Cost = 20.99 },
                new Package { Id = 23, OrderNumber = "ORD-2025-00023", CustomerId = 17, RecipientName = "Anna Devlin",      Destination = "9 Parkview, Wexford",         Type = Package.PackageType.Letter, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 20),   Weight = 0.1, AttemptedDeliveries = 0, Cost = 3.50 },
                new Package { Id = 24, OrderNumber = "ORD-2025-00024", CustomerId = 18, RecipientName = "Kate Curran",      Destination = "13 Main St, Monaghan",        Type = Package.PackageType.Parcel, Status = Package.PackageStatus.InTransit,       DeliveryDate = new DateTime(2025, 2, 22),   Weight = 2.2, AttemptedDeliveries = 3, Cost = 12.49 },
                new Package { Id = 25, OrderNumber = "ORD-2025-00025", CustomerId = 19, RecipientName = "Olivia OBrien",    Destination = "15 Hillcrest, Derry",         Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 24),   Weight = 3.4, AttemptedDeliveries = 0, Cost = 19.49 },
                new Package { Id = 26, OrderNumber = "ORD-2025-00026", CustomerId = 20, RecipientName = "Ava McLaughlin",   Destination = "19 Oak Rd, Strabane",         Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 2, 26),   Weight = 2.6, AttemptedDeliveries = 0, Cost = 13.99 },
                new Package { Id = 27, OrderNumber = "ORD-2025-00027", CustomerId = 21, RecipientName = "Molly Gallagher",  Destination = "21 Harbour St, Galway",       Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 1),    Weight = 4.1, AttemptedDeliveries = 0, Cost = 22.99 },
                new Package { Id = 28, OrderNumber = "ORD-2025-00028", CustomerId = 22, RecipientName = "Evie Kelly",       Destination = "23 Station Rd, Cork",         Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 3),    Weight = 2.8, AttemptedDeliveries = 0, Cost = 14.49 },
                new Package { Id = 29, OrderNumber = "ORD-2025-00029", CustomerId = 23, RecipientName = "Niamh Murphy",     Destination = "25 Glen Rd, Dublin",          Type = Package.PackageType.Letter, Status = Package.PackageStatus.InTransit,       DeliveryDate = new DateTime(2025, 3, 5),    Weight = 0.1, AttemptedDeliveries = 3, Cost = 4.25 },
                new Package { Id = 30, OrderNumber = "ORD-2025-00030", CustomerId = 24, RecipientName = "Clara Boyle",      Destination = "27 Bridge Ave, Sligo",        Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 7),    Weight = 3.9, AttemptedDeliveries = 0, Cost = 21.99 },
                new Package { Id = 31, OrderNumber = "ORD-2025-00031", CustomerId = 25, RecipientName = "Erin Doherty",     Destination = "29 Meadow View, Letterkenny", Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 9),    Weight = 2.1, AttemptedDeliveries = 0, Cost = 11.99 },
                new Package { Id = 32, OrderNumber = "ORD-2025-00032", CustomerId = 2,  RecipientName = "Sophie Gallagher",  Destination = "4 Main Rd, Letterkenny",     Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 11),   Weight = 1.7, AttemptedDeliveries = 0, Cost = 9.99 },
                new Package { Id = 33, OrderNumber = "ORD-2025-00033", CustomerId = 5,  RecipientName = "Lucy Boyle",        Destination = "9 Park Lane, Cork",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 13),   Weight = 1.6, AttemptedDeliveries = 0, Cost = 9.99 },
                new Package { Id = 34, OrderNumber = "ORD-2025-00034", CustomerId = 10, RecipientName = "Ella Ferry",       Destination = "6 Hilltop, Donegal",          Type = Package.PackageType.Parcel, Status = Package.PackageStatus.Delivered,       DeliveryDate = new DateTime(2025, 3, 15),   Weight = 3.6, AttemptedDeliveries = 0, Cost = 19.50 },
                new Package { Id = 35, OrderNumber = "ORD-2025-00035", CustomerId = 15, RecipientName = "Ruby McBride",     Destination = "2 Oakfield, Clare",           Type = Package.PackageType.Letter, Status = Package.PackageStatus.AwaitingPickup,  DeliveryDate = new DateTime(2025, 3, 17),   Weight = 0.1, AttemptedDeliveries = 4, Cost = 3.75 }
            );
        }
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
