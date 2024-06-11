using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class MaterialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material_xm2 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "MatName", "Material_xm2" },
                values: new object[] { 1, "BCA", 1.0 });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "MatName", "Material_xm2" },
                values: new object[] { 2, "Caramida Rosie", 1.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
