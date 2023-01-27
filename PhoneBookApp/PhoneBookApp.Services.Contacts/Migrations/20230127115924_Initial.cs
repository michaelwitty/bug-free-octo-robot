using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhoneBookApp.Services.Contacts.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("5f7b62b0-02f3-4ca0-b2cc-a12ede1cc04c"), "Steve", "Jobs", "220-454-6754" },
                    { new Guid("68c4171b-5940-4ce9-8983-9c33bb0df524"), "Bill", "Gates", "343-654-9688" },
                    { new Guid("c417164d-b9a6-4d68-b1fa-61710657cb1f"), "Steve", "Wozniak", "343-675-8786" },
                    { new Guid("f4716960-8641-4008-a0f9-dae69db71a86"), "Fred", "Allen", "210-657-9886" },
                    { new Guid("ff9e6a8e-c1cb-4d9f-8a8e-57feaf87f07b"), "Eric", "Elliot", "222-555-6575" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
