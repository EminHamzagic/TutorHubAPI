using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Predmet_PredmetId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Profesor_ProfesorId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_AspNetUsers_KorisnikId",
                table: "Zakazani");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_Profesor_ProfesorId",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Zakazani_KorisnikId",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Zakazani_ProfesorId",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Oglas_PredmetId",
                table: "Oglas");

            migrationBuilder.DropIndex(
                name: "IX_Oglas_ProfesorId",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Zakazani");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Zakazani");

            migrationBuilder.DropColumn(
                name: "PredmetId",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Oglas");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Ucenika",
                table: "Zakazani",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Zakazani_Id_Profesora",
                table: "Zakazani",
                column: "Id_Profesora");

            migrationBuilder.CreateIndex(
                name: "IX_Zakazani_Id_Ucenika",
                table: "Zakazani",
                column: "Id_Ucenika");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_Id_Predmeta",
                table: "Oglas",
                column: "Id_Predmeta");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_Id_Profesora",
                table: "Oglas",
                column: "Id_Profesora");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Predmet_Id_Predmeta",
                table: "Oglas",
                column: "Id_Predmeta",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Profesor_Id_Profesora",
                table: "Oglas",
                column: "Id_Profesora",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_AspNetUsers_Id_Ucenika",
                table: "Zakazani",
                column: "Id_Ucenika",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_Profesor_Id_Profesora",
                table: "Zakazani",
                column: "Id_Profesora",
                principalTable: "Profesor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Predmet_Id_Predmeta",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Profesor_Id_Profesora",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_AspNetUsers_Id_Ucenika",
                table: "Zakazani");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_Profesor_Id_Profesora",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Zakazani_Id_Profesora",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Zakazani_Id_Ucenika",
                table: "Zakazani");

            migrationBuilder.DropIndex(
                name: "IX_Oglas_Id_Predmeta",
                table: "Oglas");

            migrationBuilder.DropIndex(
                name: "IX_Oglas_Id_Profesora",
                table: "Oglas");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Ucenika",
                table: "Zakazani",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId",
                table: "Zakazani",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfesorId",
                table: "Zakazani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PredmetId",
                table: "Oglas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfesorId",
                table: "Oglas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zakazani_KorisnikId",
                table: "Zakazani",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zakazani_ProfesorId",
                table: "Zakazani",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_PredmetId",
                table: "Oglas",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_ProfesorId",
                table: "Oglas",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Predmet_PredmetId",
                table: "Oglas",
                column: "PredmetId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Profesor_ProfesorId",
                table: "Oglas",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_AspNetUsers_KorisnikId",
                table: "Zakazani",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_Profesor_ProfesorId",
                table: "Zakazani",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
