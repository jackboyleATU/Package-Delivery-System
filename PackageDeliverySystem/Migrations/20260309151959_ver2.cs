using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
