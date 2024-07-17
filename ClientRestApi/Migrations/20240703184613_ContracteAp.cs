using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class ContracteAp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContracteApartamenteContractApId",
                table: "AdminUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContracteApartamentes",
                columns: table => new
                {
                    ContractApId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApartamentId = table.Column<int>(type: "int", nullable: false),
                    DataSemnarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Costuri = table.Column<int>(type: "int", nullable: false),
                    PretVanzare = table.Column<int>(type: "int", nullable: false),
                    ApartamentId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContracteApartamentes", x => x.ContractApId);
                    table.ForeignKey(
                        name: "FK_ContracteApartamentes_AdminUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AdminUsers",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContracteApartamentes_Apartamente_ApartamentId",
                        column: x => x.ApartamentId,
                        principalTable: "Apartamente",
                        principalColumn: "ApartamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContracteApartamentes_Apartamente_ApartamentId1",
                        column: x => x.ApartamentId1,
                        principalTable: "Apartamente",
                        principalColumn: "ApartamentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContracteApartamentes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContracteApartamentes_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_ContracteApartamenteContractApId",
                table: "AdminUsers",
                column: "ContracteApartamenteContractApId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteApartamentes_AdminId",
                table: "ContracteApartamentes",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteApartamentes_ApartamentId",
                table: "ContracteApartamentes",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteApartamentes_ApartamentId1",
                table: "ContracteApartamentes",
                column: "ApartamentId1",
                unique: true,
                filter: "[ApartamentId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteApartamentes_UserId",
                table: "ContracteApartamentes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContracteApartamentes_UserId1",
                table: "ContracteApartamentes",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_ContracteApartamentes_ContracteApartamenteContractApId",
                table: "AdminUsers",
                column: "ContracteApartamenteContractApId",
                principalTable: "ContracteApartamentes",
                principalColumn: "ContractApId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_ContracteApartamentes_ContracteApartamenteContractApId",
                table: "AdminUsers");

            migrationBuilder.DropTable(
                name: "ContracteApartamentes");

            migrationBuilder.DropIndex(
                name: "IX_AdminUsers_ContracteApartamenteContractApId",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "ContracteApartamenteContractApId",
                table: "AdminUsers");
        }
    }
}
