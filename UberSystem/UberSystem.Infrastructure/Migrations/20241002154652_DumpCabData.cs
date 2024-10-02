using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DumpCabData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cabs",
                columns: new[] { "Id", "RegNo", "Type" },
                values: new object[,]
                {
                    { 2L, "30B-67890", "Toyota Camry - Sedan" },
                    { 3L, "29C-54321", "Honda Civic - Sedan" },
                    { 4L, "50D-11223", "Ford Fiesta - Hatchback" },
                    { 5L, "60E-98765", "Kia Sorento - SUV" },
                    { 6L, "45F-22334", "Chevrolet Cruze - Sedan" },
                    { 7L, "51G-99887", "Mazda 3 - Sedan" },
                    { 8L, "48H-45678", "Toyota Fortuner - SUV" },
                    { 9L, "55K-33445", "Hyundai Elantra - Sedan" },
                    { 10L, "61L-56789", "Mitsubishi Xpander - MPV" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 111, 14, 4, 111, 249, 226, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 167, 14, 4, 111, 249, 226, 220, 136 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 163, 93, 80, 206, 238, 226, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 230, 93, 80, 206, 238, 226, 220, 136 });
        }
    }
}
