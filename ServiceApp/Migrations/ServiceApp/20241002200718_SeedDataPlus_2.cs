using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceApp.Migrations.ServiceApp
{
    /// <inheritdoc />
    public partial class SeedDataPlus_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "ClientId", "Description", "Name" },
                values: new object[,]
                {
                    { 4, 2, "Laptop HP", "HP ENVY 15" },
                    { 5, 3, "Earphones, wireless", "Edifier 830" }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Description", "DeviceId", "Name" },
                values: new object[,]
                {
                    { 1, "n.a.", 2, "main flex" },
                    { 2, "for Iphone 6s", 1, "battery Iph.6S" },
                    { 3, "n.a.", 0, "Main camera Iph.XS" },
                    { 4, "n.a.", 0, "Top case" },
                    { 5, "n.a.", 0, "Keyboard" },
                    { 6, "n.a.", 0, "Speaker" },
                    { 7, "n.a.", 0, "LCD flex" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Parts");
        }
    }
}
