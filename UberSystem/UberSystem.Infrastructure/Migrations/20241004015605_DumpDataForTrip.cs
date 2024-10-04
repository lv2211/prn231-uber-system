using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DumpDataForTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 49, 10, 183, 180, 23, 228, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 103, 10, 183, 180, 23, 228, 220, 136 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreateAt", "CustomerId", "DestinationLatitude", "DestinationLongitude", "DriverId", "PaymentId", "SourceLatitude", "SourceLongitude", "Status" },
                values: new object[,]
                {
                    { 1L, new byte[] { 200, 226, 21, 97, 82, 228, 220, 8 }, 1L, 34.052199999999999, -118.2437, 1L, null, 37.774900000000002, -122.4194, 1 },
                    { 2L, new byte[] { 205, 226, 21, 97, 82, 228, 220, 8 }, 1L, 34.052199999999999, -118.2437, 2L, null, 40.712800000000001, -74.006, 1 },
                    { 3L, new byte[] { 208, 226, 21, 97, 82, 228, 220, 8 }, 4L, 48.8566, 2.3521999999999998, 2L, null, 51.507399999999997, -0.1278, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3L);

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
    }
}
