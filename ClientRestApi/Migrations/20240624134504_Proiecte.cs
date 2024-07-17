using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class Proiecte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proiecte",
                columns: table => new
                {
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarApartamente = table.Column<int>(type: "int", nullable: false),
                    UrlImgProiect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proiecte", x => x.ProiectId);
                });

            migrationBuilder.CreateTable(
                name: "Apartamente",
                columns: table => new
                {
                    ApartamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarApartament = table.Column<int>(type: "int", nullable: false),
                    NumarCamere = table.Column<int>(type: "int", nullable: false),
                    Suprafata = table.Column<int>(type: "int", nullable: false),
                    Compartimentare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamente", x => x.ApartamentId);
                    table.ForeignKey(
                        name: "FK_Apartamente_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "ProiectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagini",
                columns: table => new
                {
                    ImagineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagini", x => x.ImagineId);
                    table.ForeignKey(
                        name: "FK_Imagini_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "ProiectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamente_ProiectId",
                table: "Apartamente",
                column: "ProiectId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagini_ProiectId",
                table: "Imagini",
                column: "ProiectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamente");

            migrationBuilder.DropTable(
                name: "Imagini");

            migrationBuilder.DropTable(
                name: "Proiecte");
        }
    }
}
