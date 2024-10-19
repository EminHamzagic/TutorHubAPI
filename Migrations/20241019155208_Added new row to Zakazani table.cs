using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddednewrowtoZakazanitable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "vremeOd_Do",
                table: "Zakazani",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vremeOd_Do",
                table: "Zakazani");
        }
    }
}
