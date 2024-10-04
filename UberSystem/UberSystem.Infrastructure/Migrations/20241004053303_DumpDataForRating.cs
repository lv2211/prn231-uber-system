using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DumpDataForRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 8, 159, 45, 4, 54, 228, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 93, 159, 45, 4, 54, 228, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 185, 119, 140, 176, 112, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateAt",
                value: new byte[] { 188, 119, 140, 176, 112, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateAt",
                value: new byte[] { 191, 119, 140, 176, 112, 228, 220, 8 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateAt",
                value: new byte[] { 193, 119, 140, 176, 112, 228, 220, 8 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmailVerified", "Password", "Role", "UserName", "VerifiedToken" },
                values: new object[,]
                {
                    { new Guid("a98c5333-1139-4caf-bb96-86d03624d96e"), "tiendkm123@gmail.com", true, "secure_pass#2", 1, "tiendkm", null },
                    { new Guid("f6287dae-0e5c-4c5d-8fcd-cfb1ed255380"), "tienvhse172309@fpt.edu.vn", true, "passwordxxx23!", 1, "vanhoangtien", null }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CabId", "CreateAt", "Dob", "LocationLatitude", "LocationLongitude", "Status", "UserId" },
                values: new object[,]
                {
                    { 3L, null, new byte[] { 100, 159, 45, 4, 54, 228, 220, 136 }, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.762622, 106.660172, 0, new Guid("a98c5333-1139-4caf-bb96-86d03624d96e") },
                    { 4L, null, new byte[] { 109, 159, 45, 4, 54, 228, 220, 136 }, new DateTime(2003, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.849163000000001, 106.771997, 0, new Guid("f6287dae-0e5c-4c5d-8fcd-cfb1ed255380") }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CustomerId", "DriverId", "Feedback", "TripId", "TripRating" },
                values: new object[,]
                {
                    { 3L, 1L, 3L, null, null, 5 },
                    { 4L, 1L, 4L, null, null, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a98c5333-1139-4caf-bb96-86d03624d96e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6287dae-0e5c-4c5d-8fcd-cfb1ed255380"));

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

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateAt",
                value: new byte[] { 219, 162, 8, 253, 87, 228, 220, 8 });
        }
    }
}
