using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class ComboboxMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finishes",
                columns: table => new
                {
                    FinishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finish_xm2 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishes", x => x.FinishId);
                });

            migrationBuilder.CreateTable(
                name: "Heatings",
                columns: table => new
                {
                    HeatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heatings", x => x.HeatingId);
                });

            migrationBuilder.CreateTable(
                name: "Ventilations",
                columns: table => new
                {
                    VentilationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VentPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventilations", x => x.VentilationId);
                });

            migrationBuilder.CreateTable(
                name: "Wastes",
                columns: table => new
                {
                    WasteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WastePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wastes", x => x.WasteId);
                });

            migrationBuilder.InsertData(
                table: "Finishes",
                columns: new[] { "FinishId", "FinName", "Finish_xm2" },
                values: new object[,]
                {
                    { 1, "Standard", 1.0 },
                    { 2, "Premium", 2.0 },
                    { 3, "De Lux", 3.5 }
                });

            migrationBuilder.InsertData(
                table: "Heatings",
                columns: new[] { "HeatingId", "HeatName", "HeatPrice" },
                values: new object[,]
                {
                    { 1, "Centrala Termica (pe gaz)", 3000 },
                    { 2, "Centrala Termica (electrica)", 2000 },
                    { 3, "Pompa De Caldura (aer-aer)", 6500 },
                    { 4, "Pompa De Caldura (aer-apa)", 10500 },
                    { 5, "Pompa De Caldura (sol-apa)", 21500 },
                    { 6, "Soba Moderna (pe lemne/pellet)", 2500 },
                    { 7, "Soba Moderna (pe gaz)", 3500 }
                });

            migrationBuilder.InsertData(
                table: "Ventilations",
                columns: new[] { "VentilationId", "VentName", "VentPrice" },
                values: new object[,]
                {
                    { 1, "Ventilatie Naturala", 125 },
                    { 2, "Ventilatie Mecanica Simpla", 650 },
                    { 3, "Ventilatie Mecanica Controlata (VMC)", 2000 },
                    { 4, "Ventilatie Mecanica Cu Recuperare De Caldura (VMC-R)", 5250 }
                });

            migrationBuilder.InsertData(
                table: "Wastes",
                columns: new[] { "WasteId", "WasteName", "WastePrice" },
                values: new object[,]
                {
                    { 1, "Canalizare", 1250 },
                    { 2, "Fosa Septica", 6000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finishes");

            migrationBuilder.DropTable(
                name: "Heatings");

            migrationBuilder.DropTable(
                name: "Ventilations");

            migrationBuilder.DropTable(
                name: "Wastes");
        }
    }
}
