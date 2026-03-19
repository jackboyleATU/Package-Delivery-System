using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PackageDeliverySystem.DataAccess.DataAccess;
using PackageDeliverySystem.Models.Models;
using PackageDeliverySystem.Pages.PageViewModels;
using PackageDeliverySystem.Services;
using Stripe;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("PackageDeliverySystem"))
    );

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Relax password rules to allow the seeded plain passwords
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDBContext>();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

String key = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
StripeConfiguration.ApiKey = key;

app.UseAuthentication();
app.UseAuthorization();

await app.CreateRolesAsync(builder.Configuration); // seeding runs after middleware is configured

app.MapRazorPages();

app.Run();


public static class WebApplicationExtensions
{
    public static async Task<WebApplication> CreateRolesAsync(this WebApplication app, IConfiguration configuration)
    {
        using var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var db = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    
        // Ensure all roles exist
        var roles = configuration.GetSection("Roles").Get<List<string>>();
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Seed Identity accounts for all seeded employees
        var seededEmployees = db.Employees.ToList();
        foreach (var employee in seededEmployees)
        {
            var email = employee.Username + "@gmail.ie";
            var roleName = employee.Dept == Employee.Department.Admin ? "Admin" : "Driver";

            var existing = await userManager.FindByEmailAsync(email);
            if (existing != null)
            {
                // User already exists — ensure the role is still assigned
                if (!await userManager.IsInRoleAsync(existing, roleName))
                    await userManager.AddToRoleAsync(existing, roleName);
                continue;
            }

            var appUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FullName = employee.Name,
                EmployeeId = employee.Id
            };

            var result = await userManager.CreateAsync(appUser, employee.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(appUser, roleName);
            }
            else
            {
                foreach (var error in result.Errors)
                    Console.WriteLine($"[Seed] Failed to create user {email}: {error.Description}");
            }
        }

        // Seed the system admin account
        var adminEmail = configuration["SeedAdmin:Email"] ?? "admin@gmail.ie";
        var adminPassword = configuration["SeedAdmin:Password"] ?? "Admin123!";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FullName = "System Admin"
            };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (!result.Succeeded)
                return app;
        }

        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            await userManager.AddToRoleAsync(adminUser, "Admin");

        //Create Driver

        var driverEmail = configuration["SeedDriver:Email"] ?? "SeanM@gmail.com";
        var driverPassword = configuration["SeedDriver:Password"] ?? "Driver123!";

        var driverUser = await userManager.FindByEmailAsync(driverEmail);

        if (driverUser == null)
        {
            // instantiate ApplicationUser (not IdentityUser) because UserManager<ApplicationUser> is used
            driverUser = new ApplicationUser
            {
                UserName = driverEmail,
                Email = driverEmail,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(driverUser, driverPassword);
            if (!result.Succeeded)
            {
                // optional: log errors
                return app;
            }
        }
        if (!await userManager.IsInRoleAsync(driverUser, "Driver"))
        {
            await userManager.AddToRoleAsync(driverUser, "Driver");
        }

        return app;
    }
}
