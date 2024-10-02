using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDriverIdCab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Cabs");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DriverId",
                table: "Cabs",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cabs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DriverId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 214, 239, 88, 105, 188, 226, 220, 136 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new byte[] { 16, 240, 88, 105, 188, 226, 220, 136 });
        }
    }
}
