using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class num3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Packages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderNumber",
                value: "ORD-2025-00001");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderNumber",
                value: "ORD-2025-00002");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderNumber",
                value: "ORD-2025-00003");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderNumber",
                value: "ORD-2025-00004");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderNumber",
                value: "ORD-2025-00005");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderNumber",
                value: "ORD-2025-00006");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderNumber",
                value: "ORD-2025-00007");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AttemptedDeliveries", "OrderNumber" },
                values: new object[] { 3, "ORD-2025-00008" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderNumber",
                value: "ORD-2025-00009");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderNumber",
                value: "ORD-2025-00010");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderNumber",
                value: "ORD-2025-00011");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "OrderNumber",
                value: "ORD-2025-00012");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                column: "OrderNumber",
                value: "ORD-2025-00013");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                column: "OrderNumber",
                value: "ORD-2025-00014");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                column: "OrderNumber",
                value: "ORD-2025-00015");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 16,
                column: "OrderNumber",
                value: "ORD-2025-00016");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 17,
                column: "OrderNumber",
                value: "ORD-2025-00017");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AttemptedDeliveries", "OrderNumber" },
                values: new object[] { 3, "ORD-2025-00018" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 19,
                column: "OrderNumber",
                value: "ORD-2025-00019");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 20,
                column: "OrderNumber",
                value: "ORD-2025-00020");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 21,
                column: "OrderNumber",
                value: "ORD-2025-00021");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 22,
                column: "OrderNumber",
                value: "ORD-2025-00022");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 23,
                column: "OrderNumber",
                value: "ORD-2025-00023");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AttemptedDeliveries", "OrderNumber" },
                values: new object[] { 3, "ORD-2025-00024" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 25,
                column: "OrderNumber",
                value: "ORD-2025-00025");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 26,
                column: "OrderNumber",
                value: "ORD-2025-00026");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 27,
                column: "OrderNumber",
                value: "ORD-2025-00027");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 28,
                column: "OrderNumber",
                value: "ORD-2025-00028");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AttemptedDeliveries", "OrderNumber" },
                values: new object[] { 3, "ORD-2025-00029" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 30,
                column: "OrderNumber",
                value: "ORD-2025-00030");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderNumber",
                value: "ORD-2025-00031");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderNumber",
                value: "ORD-2025-00032");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderNumber",
                value: "ORD-2025-00033");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderNumber",
                value: "ORD-2025-00034");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AttemptedDeliveries", "OrderNumber" },
                values: new object[] { 4, "ORD-2025-00035" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "AttemptedDeliveries",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 18,
                column: "AttemptedDeliveries",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 24,
                column: "AttemptedDeliveries",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 29,
                column: "AttemptedDeliveries",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 35,
                column: "AttemptedDeliveries",
                value: 0);
        }
    }
}
