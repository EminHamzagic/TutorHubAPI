using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addednewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Ocena",
                table: "Profesor",
                type: "float",
                nullable: false,
                defaultValue: 10.0);

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<double>(type: "float", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Id_Profesora = table.Column<int>(type: "int", nullable: false),
                    Id_Komentatora = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocene_AspNetUsers_Id_Komentatora",
                        column: x => x.Id_Komentatora,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_Profesor_Id_Profesora",
                        column: x => x.Id_Profesora,
                        principalTable: "Profesor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_Id_Komentatora",
                table: "Ocene",
                column: "Id_Komentatora");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_Id_Profesora",
                table: "Ocene",
                column: "Id_Profesora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "Profesor");

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
    }
}
