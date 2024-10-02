using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RegNo = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: true),
                    VerifiedToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabId = table.Column<long>(type: "bigint", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationLatitude = table.Column<double>(type: "float", nullable: true),
                    LocationLongitude = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CabDriver",
                columns: table => new
                {
                    CabsId = table.Column<long>(type: "bigint", nullable: false),
                    DriversId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabDriver", x => new { x.CabsId, x.DriversId });
                    table.ForeignKey(
                        name: "FK_CabDriver_Cabs_CabsId",
                        column: x => x.CabsId,
                        principalTable: "Cabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabDriver_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SourceLatitude = table.Column<double>(type: "float", nullable: true),
                    SourceLongitude = table.Column<double>(type: "float", nullable: true),
                    DestinationLatitude = table.Column<double>(type: "float", nullable: true),
                    DestinationLongitude = table.Column<double>(type: "float", nullable: true),
                    CreateAt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Trips_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<long>(type: "bigint", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    CreateAt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    TripId = table.Column<long>(type: "bigint", nullable: true),
                    TripRating = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Ratings_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cabs",
                columns: new[] { "Id", "DriverId", "RegNo", "Type" },
                values: new object[] { 1L, 1L, "51A-12345", "Hyundai Accent - Sedan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmailVerified", "Password", "Role", "UserName", "VerifiedToken" },
                values: new object[,]
                {
                    { new Guid("4407944b-ce49-4ca4-990a-4acbc9a644e0"), "ubersystem.admin.123@example.com", null, "uberad123!", 2, "UberSystem Admin", null },
                    { new Guid("98388595-6f18-4518-acb1-0718fd336864"), "totrogias@gmail.com", true, "matkhau123!", 1, "Trần Minh Toàn", null },
                    { new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02"), "jane.doe@ubersystem.com", true, "secure_x1!_password", 0, "janedoe", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreateAt", "UserId" },
                values: new object[] { 1L, new byte[] { 214, 239, 88, 105, 188, 226, 220, 136 }, new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02") });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CabId", "CreateAt", "Dob", "LocationLatitude", "LocationLongitude", "Status", "UserId" },
                values: new object[] { 1L, null, new byte[] { 16, 240, 88, 105, 188, 226, 220, 136 }, new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, new Guid("98388595-6f18-4518-acb1-0718fd336864") });

            migrationBuilder.CreateIndex(
                name: "IX_CabDriver_DriversId",
                table: "CabDriver",
                column: "DriversId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TripId",
                table: "Payments",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DriverId",
                table: "Ratings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TripId",
                table: "Ratings",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CustomerId",
                table: "Trips",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId",
                table: "Trips",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabDriver");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Cabs");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
