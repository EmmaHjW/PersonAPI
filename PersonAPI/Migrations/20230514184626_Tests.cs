using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonAPI.Migrations
{
    /// <inheritdoc />
    public partial class Tests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_FK_PersonId",
                        column: x => x.FK_PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_InterestId = table.Column<int>(type: "int", nullable: false),
                    InterestsInterestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestsInterestId",
                        column: x => x.InterestsInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId");
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "BirthDate", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma Hjalmarsson Wahlström", "0738435459" },
                    { 2, new DateTime(1992, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aldor Besher", "0738435455" },
                    { 3, new DateTime(1982, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oskar Ullsten", "0738435465" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "FK_PersonId" },
                values: new object[,]
                {
                    { 1, "Trail running", 1 },
                    { 2, "Food & Wine", 1 },
                    { 3, "Coding", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FK_PersonId",
                table: "Interests",
                column: "FK_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestsInterestId",
                table: "Links",
                column: "InterestsInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
