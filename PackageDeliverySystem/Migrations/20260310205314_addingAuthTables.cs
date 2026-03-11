using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class addingAuthTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttemptedDeliveries",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "emma.oconnor@email.com", "0871234501" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "sophie.gallagher@email.com", "0871234502" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "aoife.kelly@email.com", "0871234503" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "sarah.murphy@email.com", "0871234504" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "lucy.boyle@email.com", "0871234505" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "grace.dunne@email.com", "0871234506" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "mia.quinn@email.com", "0871234507" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "hannah.ward@email.com", "0871234508" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "chloe.reid@email.com", "0871234509" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "ella.ferry@email.com", "0871234510" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "lily.kane@email.com", "0871234511" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "zoe.moore@email.com", "0871234512" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "isla.byrne@email.com", "0871234513" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "freya.sweeney@email.com", "0871234514" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "ruby.mcbride@email.com", "0871234515" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "emily.gillen@email.com", "0871234516" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "anna.devlin@email.com", "0871234517" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "kate.curran@email.com", "0871234518" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "olivia.obrien@email.com", "0871234519" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "ava.mclaughlin@email.com", "0871234520" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "molly.gallagher@email.com", "0871234521" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "evie.kelly@email.com", "0871234522" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "niamh.murphy@email.com", "0871234523" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "clara.boyle@email.com", "0871234524" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "erin.doherty@email.com", "0871234525" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.8 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.1000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.8999999999999999 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0999999999999996 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.8999999999999999 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.1000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.7 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AttemptedDeliveries", "DeliveryDate", "Weight" },
                values: new object[] { 0, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001 });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AttemptedDeliveries",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");
        }
    }
}
