using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumCalculatorApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    OccupationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationName = table.Column<string>(nullable: true),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.OccupationId);
                });

            migrationBuilder.CreateTable(
                name: "RatingFactor",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: false),
                    Factor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFactor", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    OccupationId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false),
                    DeathSumInsured = table.Column<decimal>(nullable: false),
                    MonthlyPremium = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Occupation_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupation",
                        principalColumn: "OccupationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Occupation",
                columns: new[] { "OccupationId", "OccupationName", "RatingId" },
                values: new object[,]
                {
                    { 1, "Cleaner", 3 },
                    { 2, "Doctor", 1 },
                    { 3, "Author", 2 },
                    { 4, "Farmer", 4 },
                    { 5, "Mechanic", 4 },
                    { 6, "Florist", 3 }
                });

            migrationBuilder.InsertData(
                table: "RatingFactor",
                columns: new[] { "RatingId", "Factor", "Rating" },
                values: new object[,]
                {
                    { 1, 1.00m, "Professional" },
                    { 2, 1.25m, "White Collar" },
                    { 3, 1.50m, "Light Manual" },
                    { 4, 1.75m, "Heavy Manual" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_OccupationId",
                table: "User",
                column: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingFactor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Occupation");
        }
    }
}
