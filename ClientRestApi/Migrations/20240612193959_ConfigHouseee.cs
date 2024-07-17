using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class ConfigHouseee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigCasas",
                columns: table => new
                {
                    ConfigCasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finisaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipIncalzire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ventilatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColectareReziduri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigCasas", x => x.ConfigCasaId);
                    table.ForeignKey(
                        name: "FK_ConfigCasas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigCameras",
                columns: table => new
                {
                    ConfigCameraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigCasaId = table.Column<int>(type: "int", nullable: false),
                    NumeCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suprafata = table.Column<int>(type: "int", nullable: false),
                    IncalzirePardoseala = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigCameras", x => x.ConfigCameraId);
                    table.ForeignKey(
                        name: "FK_ConfigCameras_ConfigCasas_ConfigCasaId",
                        column: x => x.ConfigCasaId,
                        principalTable: "ConfigCasas",
                        principalColumn: "ConfigCasaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigCameras_ConfigCasaId",
                table: "ConfigCameras",
                column: "ConfigCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigCasas_UserId",
                table: "ConfigCasas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigCameras");

            migrationBuilder.DropTable(
                name: "ConfigCasas");
        }
    }
}
