using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRestApi.Migrations
{
    public partial class AsignariCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EchipaConstructorCases",
                columns: new[] { "ConstructorCaseId", "CasaId", "ConsName", "ConsStatus" },
                values: new object[,]
                {
                    { 1, null, "FDIHouseWorkerTeam 1", "disponibil" },
                    { 2, null, "FDIHouseWorkerTeam 2", "disponibil" },
                    { 3, null, "FDIHouseWorkerTeam 3", "disponibil" },
                    { 4, null, "FDIHouseWorkerTeam 4", "disponibil" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EchipaConstructorCases",
                keyColumn: "ConstructorCaseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EchipaConstructorCases",
                keyColumn: "ConstructorCaseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EchipaConstructorCases",
                keyColumn: "ConstructorCaseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EchipaConstructorCases",
                keyColumn: "ConstructorCaseId",
                keyValue: 4);
        }
    }
}
