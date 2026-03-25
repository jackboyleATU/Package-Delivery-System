using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.PageViewModels;
using PackageDeliverySystem.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDBContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    context.Database.Migrate();

    string[] roles = { "Admin", "Driver", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Seed employee login accounts
    var employees = context.Employees.ToList();

    foreach (var employee in employees)
    {
        var email = employee.Username.Contains("@")
            ? employee.Username
            : employee.Username + "@gmail.ie";

        var existingEmployeeUser = await userManager.FindByEmailAsync(email);

        if (existingEmployeeUser == null)
        {
            var employeeUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(employeeUser, "Password123!");

            if (result.Succeeded)
            {
                string roleName = email.ToLower().Contains("admin") ? "Admin" : "Driver";

                if (await roleManager.RoleExistsAsync(roleName))
                {
                    await userManager.AddToRoleAsync(employeeUser, roleName);
                }
            }
        }
    }

    // Seed customer login accounts from seeded Customers table
    var customers = context.Customers.ToList();

    foreach (var customer in customers)
    {
        if (string.IsNullOrWhiteSpace(customer.Email))
        {
            continue;
        }

        var existingCustomerUser = await userManager.FindByEmailAsync(customer.Email);

        if (existingCustomerUser == null)
        {
            var customerUser = new ApplicationUser
            {
                UserName = customer.Email,
                Email = customer.Email,
                EmailConfirmed = true,
                CustomerId = customer.Id
            };

            var result = await userManager.CreateAsync(customerUser, "Customer123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(customerUser, "Customer");
            }
        }
        else
        {
            var needsUpdate = false;

            if (existingCustomerUser.CustomerId != customer.Id)
            {
                existingCustomerUser.CustomerId = customer.Id;
                needsUpdate = true;
            }

            if (existingCustomerUser.UserName != customer.Email)
            {
                existingCustomerUser.UserName = customer.Email;
                needsUpdate = true;
            }

            if (existingCustomerUser.Email != customer.Email)
            {
                existingCustomerUser.Email = customer.Email;
                needsUpdate = true;
            }

            if (!existingCustomerUser.EmailConfirmed)
            {
                existingCustomerUser.EmailConfirmed = true;
                needsUpdate = true;
            }

            if (needsUpdate)
            {
                await userManager.UpdateAsync(existingCustomerUser);
            }

            if (!await userManager.IsInRoleAsync(existingCustomerUser, "Customer"))
            {
                await userManager.AddToRoleAsync(existingCustomerUser, "Customer");
            }
        }
    }

    // Auto-create notifications for seeded packages that already have 3+ failed deliveries
    var packages = context.Packages.ToList();

    foreach (var package in packages.Where(p => p.AttemptedDeliveries >= 3))
    {
        var alreadyExists = context.CustomerEmails
            .Any(e => e.PackageId == package.Id && e.CustomerId == package.CustomerId);

        if (!alreadyExists)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == package.CustomerId);

            if (customer != null)
            {
                if (package.Status != Package.PackageStatus.ReturnedToSender)
                {
                    package.Status = Package.PackageStatus.ReturnedToSender;
                }

                context.CustomerEmails.Add(new CustomerEmail
                {
                    CustomerId = customer.Id,
                    PackageId = package.Id,
                    Subject = $"Returned to Sender - {package.OrderNumber}",
                    Body =
$@"Dear {customer.Name},

Your package is being returned to you address because 3 or more delivery attempts were unsuccessful.

Package Details:
Order Number: {package.OrderNumber}
Recipient Name: {package.RecipientName}
Destination: {package.Destination}
Package Type: {package.Type}
Delivery Date: {package.DeliveryDate:dd/MM/yyyy}
Weight: {package.Weight} kg
Cost: €{package.Cost:F2}
Attempted Deliveries: {package.AttemptedDeliveries}
Current Status: {Package.PackageStatus.ReturnedToSender}

Your Package cost has been refunded to the credit card used for payment. You can place a new order at any time.

Please contact support if you need any further help.

Regards,
LK Post",
                    SentAt = DateTime.Now,
                    IsRead = false
                });
            }
        }
    }

    await context.SaveChangesAsync();
}

app.Run();