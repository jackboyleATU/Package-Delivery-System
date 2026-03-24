using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class Email2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "emma.oconnor@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "sophie.gallagher@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "aoife.kelly@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "sarah.murphy@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "lucy.boyle@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "grace.dunne@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Email",
                value: "mia.quinn@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Email",
                value: "hannah.ward@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Email",
                value: "chloe.reid@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Email",
                value: "ella.ferry@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Email",
                value: "lily.kane@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Email",
                value: "zoe.moore@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Email",
                value: "isla.byrne@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: "freya.sweeney@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Email",
                value: "ruby.mcbride@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16,
                column: "Email",
                value: "emily.gillen@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17,
                column: "Email",
                value: "anna.devlin@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18,
                column: "Email",
                value: "kate.curran@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19,
                column: "Email",
                value: "olivia.obrien@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20,
                column: "Email",
                value: "ava.mclaughlin@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21,
                column: "Email",
                value: "molly.gallagher@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22,
                column: "Email",
                value: "evie.kelly@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23,
                column: "Email",
                value: "niamh.murphy@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24,
                column: "Email",
                value: "clara.boyle@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25,
                column: "Email",
                value: "erin.doherty@gmail.ie");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "SeanM@gmail.ie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "emma.oconnor@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "sophie.gallagher@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "aoife.kelly@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "sarah.murphy@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "lucy.boyle@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "grace.dunne@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Email",
                value: "mia.quinn@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Email",
                value: "hannah.ward@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Email",
                value: "chloe.reid@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Email",
                value: "ella.ferry@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Email",
                value: "lily.kane@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Email",
                value: "zoe.moore@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Email",
                value: "isla.byrne@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Email",
                value: "freya.sweeney@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Email",
                value: "ruby.mcbride@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16,
                column: "Email",
                value: "emily.gillen@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17,
                column: "Email",
                value: "anna.devlin@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18,
                column: "Email",
                value: "kate.curran@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19,
                column: "Email",
                value: "olivia.obrien@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20,
                column: "Email",
                value: "ava.mclaughlin@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21,
                column: "Email",
                value: "molly.gallagher@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22,
                column: "Email",
                value: "evie.kelly@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23,
                column: "Email",
                value: "niamh.murphy@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24,
                column: "Email",
                value: "clara.boyle@email.ie");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25,
                column: "Email",
                value: "erin.doherty@email.ie");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "SeanM@gmail.com");
        }
    }
}
