using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class CaseSiAsignareCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentHistoryHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructorCaseId = table.Column<int>(type: "int", nullable: false),
                    CasaId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentHistoryHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasaVandutas",
                columns: table => new
                {
                    CasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarCamere = table.Column<int>(type: "int", nullable: false),
                    Suprafata = table.Column<int>(type: "int", nullable: false),
                    Etaje = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetaliiCasa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaVandutas", x => x.CasaId);
                });

            migrationBuilder.CreateTable(
                name: "EchipaConstructorCases",
                columns: table => new
                {
                    ConstructorCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchipaConstructorCases", x => x.ConstructorCaseId);
                    table.ForeignKey(
                        name: "FK_EchipaConstructorCases_CasaVandutas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "CasaVandutas",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipaConstructorCases_CasaId",
                table: "EchipaConstructorCases",
                column: "CasaId",
                unique: true,
                filter: "[CasaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentHistoryHouses");

            migrationBuilder.DropTable(
                name: "EchipaConstructorCases");

            migrationBuilder.DropTable(
                name: "CasaVandutas");
        }
    }
}
