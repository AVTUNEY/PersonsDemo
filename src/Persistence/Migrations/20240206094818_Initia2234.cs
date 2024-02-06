using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initia2234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalPersons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ConnectedPersonId = table.Column<int>(type: "int", nullable: true),
                    ConnectionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonConnections_PhysicalPersons_ConnectedPersonId",
                        column: x => x.ConnectedPersonId,
                        principalTable: "PhysicalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonConnections_PhysicalPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PhysicalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhysicalPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhysicalPersons_PhysicalPersonId",
                        column: x => x.PhysicalPersonId,
                        principalTable: "PhysicalPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Batumi" },
                    { 3, "Gori" }
                });

            migrationBuilder.InsertData(
                table: "PhysicalPersons",
                columns: new[] { "Id", "BirthDate", "CityId", "FirstName", "Gender", "ImagePath", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "John", 2, "john.jpg", "Doe", "123456789" },
                    { 2, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Alice", 1, "alice.jpg", "Smith", "987654321" },
                    { 3, new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bob", 2, "bob.jpg", "Johnson", "555555555" },
                    { 4, new DateTime(1980, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eva", 1, "eva.jpg", "Brown", "111111111" },
                    { 5, new DateTime(1992, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "John", 2, "john_smith.jpg", "Smith", "555123123" },
                    { 6, new DateTime(1987, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "John", 2, "john_williams.jpg", "Williams", "999888777" }
                });

            migrationBuilder.InsertData(
                table: "PersonConnections",
                columns: new[] { "Id", "ConnectedPersonId", "ConnectionType", "PersonId" },
                values: new object[,]
                {
                    { 1, 2, 2, 1 },
                    { 2, 4, 1, 3 },
                    { 3, 1, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "PhysicalPersonId", "Type" },
                values: new object[,]
                {
                    { 1, "24324", 1, 3 },
                    { 2, "123", 1, 1 },
                    { 3, "54543", 2, 2 },
                    { 4, "437", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonConnections_ConnectedPersonId",
                table: "PersonConnections",
                column: "ConnectedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonConnections_PersonId_ConnectedPersonId",
                table: "PersonConnections",
                columns: new[] { "PersonId", "ConnectedPersonId" },
                unique: true,
                filter: "[PersonId] IS NOT NULL AND [ConnectedPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhysicalPersonId",
                table: "PhoneNumbers",
                column: "PhysicalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersons_CityId",
                table: "PhysicalPersons",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonConnections");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "PhysicalPersons");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
