using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_CustomerId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientName",
                table: "Packages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Packages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PPS",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "12 Hill St, Derry", "Emma OConnor" },
                    { 2, "4 Main Rd, Letterkenny", "Sophie Gallagher" },
                    { 3, "8 River Walk, Buncrana", "Aoife Kelly" },
                    { 4, "22 Oak Ave, Dublin", "Sarah Murphy" },
                    { 5, "9 Park Lane, Cork", "Lucy Boyle" },
                    { 6, "1 Green Rd, Galway", "Grace Dunne" },
                    { 7, "3 Harbour View, Sligo", "Mia Quinn" },
                    { 8, "7 Meadow Rd, Limerick", "Hannah Ward" },
                    { 9, "14 Bridge St, Waterford", "Chloe Reid" },
                    { 10, "6 Hilltop, Donegal", "Ella Ferry" },
                    { 11, "18 Pine Rd, Armagh", "Lily Kane" },
                    { 12, "5 Cedar Ave, Newry", "Zoe Moore" },
                    { 13, "11 Glen St, Dundalk", "Isla Byrne" },
                    { 14, "20 Church Rd, Kilkenny", "Freya Sweeney" },
                    { 15, "2 Oakfield, Clare", "Ruby McBride" },
                    { 16, "17 Riverbank, Mayo", "Emily Gillen" },
                    { 17, "9 Parkview, Wexford", "Anna Devlin" },
                    { 18, "13 Main St, Monaghan", "Kate Curran" },
                    { 19, "15 Hillcrest, Derry", "Olivia OBrien" },
                    { 20, "19 Oak Rd, Strabane", "Ava McLaughlin" },
                    { 21, "21 Harbour St, Galway", "Molly Gallagher" },
                    { 22, "23 Station Rd, Cork", "Evie Kelly" },
                    { 23, "25 Glen Rd, Dublin", "Niamh Murphy" },
                    { 24, "27 Bridge Ave, Sligo", "Clara Boyle" },
                    { 25, "29 Meadow View, Letterkenny", "Erin Doherty" }
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
                columns: new[] { "Id", "Cost", "CustomerId", "Destination", "RecipientName", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 12.99, 1, "12 Hill St, Derry", "Emma OConnor", 2, 1 },
                    { 2, 4.9900000000000002, 1, "12 Hill St, Derry", "Emma OConnor", 1, 0 },
                    { 3, 18.989999999999998, 2, "4 Main Rd, Letterkenny", "Sophie Gallagher", 0, 1 },
                    { 4, 4.5, 2, "4 Main Rd, Letterkenny", "Sophie Gallagher", 2, 0 },
                    { 5, 14.5, 3, "8 River Walk, Buncrana", "Aoife Kelly", 2, 1 },
                    { 6, 4.2000000000000002, 3, "8 River Walk, Buncrana", "Aoife Kelly", 2, 0 },
                    { 7, 22.5, 4, "22 Oak Ave, Dublin", "Sarah Murphy", 2, 1 },
                    { 8, 11.75, 4, "22 Oak Ave, Dublin", "Sarah Murphy", 1, 1 },
                    { 9, 3.9900000000000002, 5, "9 Park Lane, Cork", "Lucy Boyle", 0, 0 },
                    { 10, 20.0, 5, "9 Park Lane, Cork", "Lucy Boyle", 2, 1 },
                    { 11, 10.75, 6, "1 Green Rd, Galway", "Grace Dunne", 2, 1 },
                    { 12, 19.989999999999998, 7, "3 Harbour View, Sligo", "Mia Quinn", 0, 1 },
                    { 13, 11.5, 8, "7 Meadow Rd, Limerick", "Hannah Ward", 2, 1 },
                    { 14, 24.989999999999998, 9, "14 Bridge St, Waterford", "Chloe Reid", 2, 1 },
                    { 15, 12.75, 10, "6 Hilltop, Donegal", "Ella Ferry", 0, 1 },
                    { 16, 4.0999999999999996, 10, "6 Hilltop, Donegal", "Ella Ferry", 2, 0 },
                    { 17, 13.4, 11, "18 Pine Rd, Armagh", "Lily Kane", 2, 1 },
                    { 18, 21.0, 12, "5 Cedar Ave, Newry", "Zoe Moore", 1, 1 },
                    { 19, 15.99, 13, "11 Glen St, Dundalk", "Isla Byrne", 2, 1 },
                    { 20, 23.989999999999998, 14, "20 Church Rd, Kilkenny", "Freya Sweeney", 2, 1 },
                    { 21, 8.9900000000000002, 15, "2 Oakfield, Clare", "Ruby McBride", 2, 1 },
                    { 22, 20.989999999999998, 16, "17 Riverbank, Mayo", "Emily Gillen", 0, 1 },
                    { 23, 3.5, 17, "9 Parkview, Wexford", "Anna Devlin", 2, 0 },
                    { 24, 12.49, 18, "13 Main St, Monaghan", "Kate Curran", 1, 1 },
                    { 25, 19.489999999999998, 19, "15 Hillcrest, Derry", "Olivia OBrien", 2, 1 },
                    { 26, 13.99, 20, "19 Oak Rd, Strabane", "Ava McLaughlin", 2, 1 },
                    { 27, 22.989999999999998, 21, "21 Harbour St, Galway", "Molly Gallagher", 2, 1 },
                    { 28, 14.49, 22, "23 Station Rd, Cork", "Evie Kelly", 2, 1 },
                    { 29, 4.25, 23, "25 Glen Rd, Dublin", "Niamh Murphy", 1, 0 },
                    { 30, 21.989999999999998, 24, "27 Bridge Ave, Sligo", "Clara Boyle", 2, 1 },
                    { 31, 11.99, 25, "29 Meadow View, Letterkenny", "Erin Doherty", 2, 1 },
                    { 32, 9.9900000000000002, 2, "4 Main Rd, Letterkenny", "Sophie Gallagher", 2, 1 },
                    { 33, 9.9900000000000002, 5, "9 Park Lane, Cork", "Lucy Boyle", 2, 1 },
                    { 34, 19.5, 10, "6 Hilltop, Donegal", "Ella Ferry", 2, 1 },
                    { 35, 3.75, 15, "2 Oakfield, Clare", "Ruby McBride", 0, 0 }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_CustomerId",
                table: "Packages",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_CustomerId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PPS",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Username",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PPS",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_CustomerId",
                table: "Packages",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
