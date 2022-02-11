using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClubApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    GymID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.GymID);
                });

            migrationBuilder.CreateTable(
                name: "SelectionAges",
                columns: table => new
                {
                    SelectionAgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionAgeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionAges", x => x.SelectionAgeID);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionAgeID = table.Column<int>(type: "int", nullable: false),
                    SelectionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.SelectionID);
                    table.ForeignKey(
                        name: "FK_Selections_SelectionAges_SelectionAgeID",
                        column: x => x.SelectionAgeID,
                        principalTable: "SelectionAges",
                        principalColumn: "SelectionAgeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    SelectionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    CoachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_Trainings_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, 240798 },
                    { 2, 897042 }
                });

            migrationBuilder.InsertData(
                table: "SelectionAges",
                columns: new[] { "SelectionAgeID", "SelectionAgeName" },
                values: new object[,]
                {
                    { 1, "Under 10" },
                    { 2, "Under 12" },
                    { 3, "Under 14" },
                    { 4, "Under 16" },
                    { 5, "Juniors" },
                    { 6, "Seniors" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_SelectionID",
                table: "Players",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_SelectionAgeID",
                table: "Selections",
                column: "SelectionAgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachID",
                table: "Trainings",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GymID",
                table: "Trainings",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_SelectionID",
                table: "Trainings",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectionID",
                table: "Users",
                column: "SelectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "SelectionAges");
        }
    }
}
