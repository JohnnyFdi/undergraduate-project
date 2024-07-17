using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class ContracteCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContracteCases",
                columns: table => new
                {
                    ContractCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CasaId = table.Column<int>(type: "int", nullable: false),
                    DataSemnarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Costuri = table.Column<int>(type: "int", nullable: false),
                    PretVanzare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContracteCases", x => x.ContractCId);
                    table.ForeignKey(
                        name: "FK_ContracteCases_AdminUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AdminUsers",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContracteCases_CasaVandutas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "CasaVandutas",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContracteCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContracteCases_AdminId",
                table: "ContracteCases",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteCases_CasaId",
                table: "ContracteCases",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteCases_UserId",
                table: "ContracteCases",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContracteCases");
        }
    }
}
