using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddednewcolumntotableOglas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Namenjeno_Obrazovanje",
                table: "Oglas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namenjeno_Obrazovanje",
                table: "Oglas");
        }
    }
}
