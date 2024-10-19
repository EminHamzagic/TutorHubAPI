using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddednewrowtoProfessortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pfpUrl",
                table: "Profesor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pfpUrl",
                table: "Profesor");
        }
    }
}
