using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "630c2425-23cf-4da9-be77-e8dc8d20eb79", "630c2425-23cf-4da9-be77-e8dc8d20eb79", "User", "USER" },
                    { "fff052ce-b85c-4131-b667-617640718911", "fff052ce-b85c-4131-b667-617640718911", "Admin", "ADMIN" },
                    { "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p", "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p", "Professor", "PROFESSOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "630c2425-23cf-4da9-be77-e8dc8d20eb79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fff052ce-b85c-4131-b667-617640718911");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p");
        }
    }
}
