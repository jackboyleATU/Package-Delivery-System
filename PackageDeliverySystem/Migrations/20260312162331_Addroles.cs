using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class Addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dept = table.Column<int>(type: "int", nullable: false),
                    PPS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    AttemptedDeliveries = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "12 Hill St, Derry", "emma.oconnor@email.com", "Emma OConnor", "0871234501" },
                    { 2, "4 Main Rd, Letterkenny", "sophie.gallagher@email.com", "Sophie Gallagher", "0871234502" },
                    { 3, "8 River Walk, Buncrana", "aoife.kelly@email.com", "Aoife Kelly", "0871234503" },
                    { 4, "22 Oak Ave, Dublin", "sarah.murphy@email.com", "Sarah Murphy", "0871234504" },
                    { 5, "9 Park Lane, Cork", "lucy.boyle@email.com", "Lucy Boyle", "0871234505" },
                    { 6, "1 Green Rd, Galway", "grace.dunne@email.com", "Grace Dunne", "0871234506" },
                    { 7, "3 Harbour View, Sligo", "mia.quinn@email.com", "Mia Quinn", "0871234507" },
                    { 8, "7 Meadow Rd, Limerick", "hannah.ward@email.com", "Hannah Ward", "0871234508" },
                    { 9, "14 Bridge St, Waterford", "chloe.reid@email.com", "Chloe Reid", "0871234509" },
                    { 10, "6 Hilltop, Donegal", "ella.ferry@email.com", "Ella Ferry", "0871234510" },
                    { 11, "18 Pine Rd, Armagh", "lily.kane@email.com", "Lily Kane", "0871234511" },
                    { 12, "5 Cedar Ave, Newry", "zoe.moore@email.com", "Zoe Moore", "0871234512" },
                    { 13, "11 Glen St, Dundalk", "isla.byrne@email.com", "Isla Byrne", "0871234513" },
                    { 14, "20 Church Rd, Kilkenny", "freya.sweeney@email.com", "Freya Sweeney", "0871234514" },
                    { 15, "2 Oakfield, Clare", "ruby.mcbride@email.com", "Ruby McBride", "0871234515" },
                    { 16, "17 Riverbank, Mayo", "emily.gillen@email.com", "Emily Gillen", "0871234516" },
                    { 17, "9 Parkview, Wexford", "anna.devlin@email.com", "Anna Devlin", "0871234517" },
                    { 18, "13 Main St, Monaghan", "kate.curran@email.com", "Kate Curran", "0871234518" },
                    { 19, "15 Hillcrest, Derry", "olivia.obrien@email.com", "Olivia OBrien", "0871234519" },
                    { 20, "19 Oak Rd, Strabane", "ava.mclaughlin@email.com", "Ava McLaughlin", "0871234520" },
                    { 21, "21 Harbour St, Galway", "molly.gallagher@email.com", "Molly Gallagher", "0871234521" },
                    { 22, "23 Station Rd, Cork", "evie.kelly@email.com", "Evie Kelly", "0871234522" },
                    { 23, "25 Glen Rd, Dublin", "niamh.murphy@email.com", "Niamh Murphy", "0871234523" },
                    { 24, "27 Bridge Ave, Sligo", "clara.boyle@email.com", "Clara Boyle", "0871234524" },
                    { 25, "29 Meadow View, Letterkenny", "erin.doherty@email.com", "Erin Doherty", "0871234525" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DateOfBirth", "Dept", "Name", "PPS", "Password", "Salary", "Username" },
                values: new object[,]
                {
                    { 1, "12 Oak Drive, Derry", new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sean Murphy", "1234567AB", "pass123", 35000.0, "driver1" },
                    { 2, "45 Elm Park, Letterkenny", new DateTime(1988, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Conor Kelly", "2345678BC", "pass123", 36000.0, "driver2" },
                    { 3, "22 Hillcrest, Dublin", new DateTime(1992, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Patrick Doherty", "3456789CD", "admin123", 50000.0, "admin1" },
                    { 4, "7 Meadow View, Derry", new DateTime(1999, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ethan Curran", "4567890DE", "admin123", 52000.0, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "AttemptedDeliveries", "Cost", "CustomerId", "DeliveryDate", "Destination", "OrderNumber", "RecipientName", "Status", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, 0, 12.99, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Hill St, Derry", "ORD-2025-00001", "Emma OConnor", 3, 1, 2.5 },
                    { 2, 0, 4.9900000000000002, 1, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Hill St, Derry", "ORD-2025-00002", "Emma OConnor", 2, 0, 0.10000000000000001 },
                    { 3, 0, 18.989999999999998, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 Main Rd, Letterkenny", "ORD-2025-00003", "Sophie Gallagher", 1, 1, 3.2000000000000002 },
                    { 4, 0, 4.5, 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 Main Rd, Letterkenny", "ORD-2025-00004", "Sophie Gallagher", 3, 0, 0.10000000000000001 },
                    { 5, 0, 14.5, 3, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 River Walk, Buncrana", "ORD-2025-00005", "Aoife Kelly", 3, 1, 1.8 },
                    { 6, 0, 4.2000000000000002, 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 River Walk, Buncrana", "ORD-2025-00006", "Aoife Kelly", 3, 0, 0.10000000000000001 },
                    { 7, 0, 22.5, 4, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "22 Oak Ave, Dublin", "ORD-2025-00007", "Sarah Murphy", 3, 1, 4.0 },
                    { 8, 3, 11.75, 4, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "22 Oak Ave, Dublin", "ORD-2025-00008", "Sarah Murphy", 2, 1, 2.1000000000000001 },
                    { 9, 0, 3.9900000000000002, 5, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 Park Lane, Cork", "ORD-2025-00009", "Lucy Boyle", 1, 0, 0.10000000000000001 },
                    { 10, 0, 20.0, 5, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 Park Lane, Cork", "ORD-2025-00010", "Lucy Boyle", 3, 1, 3.5 },
                    { 11, 0, 10.75, 6, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 Green Rd, Galway", "ORD-2025-00011", "Grace Dunne", 3, 1, 1.8999999999999999 },
                    { 12, 0, 19.989999999999998, 7, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Harbour View, Sligo", "ORD-2025-00012", "Mia Quinn", 1, 1, 3.2999999999999998 },
                    { 13, 0, 11.5, 8, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 Meadow Rd, Limerick", "ORD-2025-00013", "Hannah Ward", 3, 1, 2.0 },
                    { 14, 0, 24.989999999999998, 9, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "14 Bridge St, Waterford", "ORD-2025-00014", "Chloe Reid", 3, 1, 4.5 },
                    { 15, 0, 12.75, 10, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 Hilltop, Donegal", "ORD-2025-00015", "Ella Ferry", 1, 1, 2.2999999999999998 },
                    { 16, 0, 4.0999999999999996, 10, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 Hilltop, Donegal", "ORD-2025-00016", "Ella Ferry", 3, 0, 0.10000000000000001 },
                    { 17, 0, 13.4, 11, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "18 Pine Rd, Armagh", "ORD-2025-00017", "Lily Kane", 3, 1, 2.3999999999999999 },
                    { 18, 3, 21.0, 12, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 Cedar Ave, Newry", "ORD-2025-00018", "Zoe Moore", 2, 1, 3.7999999999999998 },
                    { 19, 0, 15.99, 13, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "11 Glen St, Dundalk", "ORD-2025-00019", "Isla Byrne", 3, 1, 2.7000000000000002 },
                    { 20, 0, 23.989999999999998, 14, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "20 Church Rd, Kilkenny", "ORD-2025-00020", "Freya Sweeney", 3, 1, 4.2000000000000002 },
                    { 21, 0, 8.9900000000000002, 15, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 Oakfield, Clare", "ORD-2025-00021", "Ruby McBride", 3, 1, 1.5 },
                    { 22, 0, 20.989999999999998, 16, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "17 Riverbank, Mayo", "ORD-2025-00022", "Emily Gillen", 1, 1, 3.7000000000000002 },
                    { 23, 0, 3.5, 17, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 Parkview, Wexford", "ORD-2025-00023", "Anna Devlin", 3, 0, 0.10000000000000001 },
                    { 24, 3, 12.49, 18, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "13 Main St, Monaghan", "ORD-2025-00024", "Kate Curran", 2, 1, 2.2000000000000002 },
                    { 25, 0, 19.489999999999998, 19, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "15 Hillcrest, Derry", "ORD-2025-00025", "Olivia OBrien", 3, 1, 3.3999999999999999 },
                    { 26, 0, 13.99, 20, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "19 Oak Rd, Strabane", "ORD-2025-00026", "Ava McLaughlin", 3, 1, 2.6000000000000001 },
                    { 27, 0, 22.989999999999998, 21, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "21 Harbour St, Galway", "ORD-2025-00027", "Molly Gallagher", 3, 1, 4.0999999999999996 },
                    { 28, 0, 14.49, 22, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "23 Station Rd, Cork", "ORD-2025-00028", "Evie Kelly", 3, 1, 2.7999999999999998 },
                    { 29, 3, 4.25, 23, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "25 Glen Rd, Dublin", "ORD-2025-00029", "Niamh Murphy", 2, 0, 0.10000000000000001 },
                    { 30, 0, 21.989999999999998, 24, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "27 Bridge Ave, Sligo", "ORD-2025-00030", "Clara Boyle", 3, 1, 3.8999999999999999 },
                    { 31, 0, 11.99, 25, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "29 Meadow View, Letterkenny", "ORD-2025-00031", "Erin Doherty", 3, 1, 2.1000000000000001 },
                    { 32, 0, 9.9900000000000002, 2, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 Main Rd, Letterkenny", "ORD-2025-00032", "Sophie Gallagher", 3, 1, 1.7 },
                    { 33, 0, 9.9900000000000002, 5, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 Park Lane, Cork", "ORD-2025-00033", "Lucy Boyle", 3, 1, 1.6000000000000001 },
                    { 34, 0, 19.5, 10, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 Hilltop, Donegal", "ORD-2025-00034", "Ella Ferry", 3, 1, 3.6000000000000001 },
                    { 35, 4, 3.75, 15, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 Oakfield, Clare", "ORD-2025-00035", "Ruby McBride", 1, 0, 0.10000000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PPS",
                table: "Employees",
                column: "PPS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CustomerId",
                table: "Packages",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
