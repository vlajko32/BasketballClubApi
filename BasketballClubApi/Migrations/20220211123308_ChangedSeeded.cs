using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClubApi.Migrations
{
    public partial class ChangedSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3, 182429 });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Value" },
                values: new object[] { 4, 292418 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Codes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Codes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "SelectionAges",
                columns: new[] { "SelectionAgeID", "SelectionAgeName" },
                values: new object[] { 1, "Under 10" });
        }
    }
}
