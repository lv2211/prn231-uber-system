using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedingDataForTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 68, 202, 169, 80, 29, 228, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 135, 202, 169, 80, 29, 228, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 209, 162, 8, 253, 87, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateAt",
                value: new byte[] { 213, 162, 8, 253, 87, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateAt",
                value: new byte[] { 216, 162, 8, 253, 87, 228, 220, 8 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreateAt", "CustomerId", "DestinationLatitude", "DestinationLongitude", "DriverId", "PaymentId", "SourceLatitude", "SourceLongitude", "Status" },
                values: new object[] { 4L, new byte[] { 219, 162, 8, 253, 87, 228, 220, 8 }, 4L, 35.689500000000002, 139.6917, 2L, null, 40.712800000000001, -74.006, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4L);

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

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 200, 226, 21, 97, 82, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateAt",
                value: new byte[] { 205, 226, 21, 97, 82, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateAt",
                value: new byte[] { 208, 226, 21, 97, 82, 228, 220, 8 });
        }
    }
}
