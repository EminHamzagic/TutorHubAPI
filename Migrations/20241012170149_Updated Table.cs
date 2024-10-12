using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profesor_Id_Korisnik",
                table: "Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Id_Korisnik",
                table: "Profesor",
                column: "Id_Korisnik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profesor_Id_Korisnik",
                table: "Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Id_Korisnik",
                table: "Profesor",
                column: "Id_Korisnik",
                unique: true);
        }
    }
}
