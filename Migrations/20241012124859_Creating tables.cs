using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class Creatingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Predmets_PredmetId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Profesors_ProfesorId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfesor_Predmets_PredmetsId",
                table: "PredmetProfesor");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfesor_Profesors_ProfesorsId",
                table: "PredmetProfesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesors_AspNetUsers_Id_Korisnik",
                table: "Profesors");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminis_Oglas_OglasId",
                table: "Terminis");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazanis_AspNetUsers_KorisnikId",
                table: "Zakazanis");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazanis_Oglas_Id_Oglasa",
                table: "Zakazanis");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazanis_Profesors_ProfesorId",
                table: "Zakazanis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zakazanis",
                table: "Zakazanis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminis",
                table: "Terminis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesors",
                table: "Profesors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predmets",
                table: "Predmets");

            migrationBuilder.RenameTable(
                name: "Zakazanis",
                newName: "Zakazani");

            migrationBuilder.RenameTable(
                name: "Terminis",
                newName: "Termini");

            migrationBuilder.RenameTable(
                name: "Profesors",
                newName: "Profesor");

            migrationBuilder.RenameTable(
                name: "Predmets",
                newName: "Predmet");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazanis_ProfesorId",
                table: "Zakazani",
                newName: "IX_Zakazani_ProfesorId");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazanis_KorisnikId",
                table: "Zakazani",
                newName: "IX_Zakazani_KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazanis_Id_Oglasa",
                table: "Zakazani",
                newName: "IX_Zakazani_Id_Oglasa");

            migrationBuilder.RenameIndex(
                name: "IX_Terminis_OglasId",
                table: "Termini",
                newName: "IX_Termini_OglasId");

            migrationBuilder.RenameIndex(
                name: "IX_Profesors_Id_Korisnik",
                table: "Profesor",
                newName: "IX_Profesor_Id_Korisnik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zakazani",
                table: "Zakazani",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Termini",
                table: "Termini",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predmet",
                table: "Predmet",
                column: "Id");

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
                name: "FK_PredmetProfesor_Predmet_PredmetsId",
                table: "PredmetProfesor",
                column: "PredmetsId",
                principalTable: "Predmet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetProfesor_Profesor_ProfesorsId",
                table: "PredmetProfesor",
                column: "ProfesorsId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_AspNetUsers_Id_Korisnik",
                table: "Profesor",
                column: "Id_Korisnik",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Oglas_OglasId",
                table: "Termini",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_AspNetUsers_KorisnikId",
                table: "Zakazani",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_Oglas_Id_Oglasa",
                table: "Zakazani",
                column: "Id_Oglasa",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazani_Profesor_ProfesorId",
                table: "Zakazani",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Predmet_PredmetId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Profesor_ProfesorId",
                table: "Oglas");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfesor_Predmet_PredmetsId",
                table: "PredmetProfesor");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfesor_Profesor_ProfesorsId",
                table: "PredmetProfesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_AspNetUsers_Id_Korisnik",
                table: "Profesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Oglas_OglasId",
                table: "Termini");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_AspNetUsers_KorisnikId",
                table: "Zakazani");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_Oglas_Id_Oglasa",
                table: "Zakazani");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazani_Profesor_ProfesorId",
                table: "Zakazani");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zakazani",
                table: "Zakazani");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Termini",
                table: "Termini");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predmet",
                table: "Predmet");

            migrationBuilder.RenameTable(
                name: "Zakazani",
                newName: "Zakazanis");

            migrationBuilder.RenameTable(
                name: "Termini",
                newName: "Terminis");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesors");

            migrationBuilder.RenameTable(
                name: "Predmet",
                newName: "Predmets");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazani_ProfesorId",
                table: "Zakazanis",
                newName: "IX_Zakazanis_ProfesorId");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazani_KorisnikId",
                table: "Zakazanis",
                newName: "IX_Zakazanis_KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Zakazani_Id_Oglasa",
                table: "Zakazanis",
                newName: "IX_Zakazanis_Id_Oglasa");

            migrationBuilder.RenameIndex(
                name: "IX_Termini_OglasId",
                table: "Terminis",
                newName: "IX_Terminis_OglasId");

            migrationBuilder.RenameIndex(
                name: "IX_Profesor_Id_Korisnik",
                table: "Profesors",
                newName: "IX_Profesors_Id_Korisnik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zakazanis",
                table: "Zakazanis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminis",
                table: "Terminis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesors",
                table: "Profesors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predmets",
                table: "Predmets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Predmets_PredmetId",
                table: "Oglas",
                column: "PredmetId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Profesors_ProfesorId",
                table: "Oglas",
                column: "ProfesorId",
                principalTable: "Profesors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetProfesor_Predmets_PredmetsId",
                table: "PredmetProfesor",
                column: "PredmetsId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetProfesor_Profesors_ProfesorsId",
                table: "PredmetProfesor",
                column: "ProfesorsId",
                principalTable: "Profesors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesors_AspNetUsers_Id_Korisnik",
                table: "Profesors",
                column: "Id_Korisnik",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Terminis_Oglas_OglasId",
                table: "Terminis",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazanis_AspNetUsers_KorisnikId",
                table: "Zakazanis",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazanis_Oglas_Id_Oglasa",
                table: "Zakazanis",
                column: "Id_Oglasa",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazanis_Profesors_ProfesorId",
                table: "Zakazanis",
                column: "ProfesorId",
                principalTable: "Profesors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
