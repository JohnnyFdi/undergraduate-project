using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class Constructori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EchipaConstructorBlocuris",
                columns: table => new
                {
                    ConstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProiectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchipaConstructorBlocuris", x => x.ConstructorId);
                    table.ForeignKey(
                        name: "FK_EchipaConstructorBlocuris_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "ProiectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EchipaConstructorBlocuris",
                columns: new[] { "ConstructorId", "ConsName", "ConsStatus", "ProiectId" },
                values: new object[,]
                {
                    { 1, "FDIWorkerTeam 1", "disponibil", null },
                    { 2, "FDIWorkerTeam 2", "disponibil", null },
                    { 3, "FDIWorkerTeam 3", "disponibil", null },
                    { 4, "FDIWorkerTeam 4", "disponibil", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipaConstructorBlocuris_ProiectId",
                table: "EchipaConstructorBlocuris",
                column: "ProiectId",
                unique: true,
                filter: "[ProiectId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EchipaConstructorBlocuris");
        }
    }
}
