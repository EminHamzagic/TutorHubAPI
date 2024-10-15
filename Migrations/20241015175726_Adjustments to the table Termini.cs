using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentstothetableTermini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Oglas_OglasId",
                table: "Termini");

            migrationBuilder.DropIndex(
                name: "IX_Termini_OglasId",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "OglasId",
                table: "Termini");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_Id_Oglasa",
                table: "Termini",
                column: "Id_Oglasa");

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Oglas_Id_Oglasa",
                table: "Termini",
                column: "Id_Oglasa",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Oglas_Id_Oglasa",
                table: "Termini");

            migrationBuilder.DropIndex(
                name: "IX_Termini_Id_Oglasa",
                table: "Termini");

            migrationBuilder.AddColumn<int>(
                name: "OglasId",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Termini_OglasId",
                table: "Termini",
                column: "OglasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Oglas_OglasId",
                table: "Termini",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
