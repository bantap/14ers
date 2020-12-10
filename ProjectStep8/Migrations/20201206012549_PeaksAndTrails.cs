using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectStep8.Migrations
{
    public partial class PeaksAndTrails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Elevation = table.Column<int>(nullable: false),
                    NearestTown = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StartingElevation = table.Column<int>(nullable: false),
                    Distance = table.Column<float>(nullable: false),
                    PeakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trail_Peak_PeakId",
                        column: x => x.PeakId,
                        principalTable: "Peak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Peak",
                columns: new[] { "Id", "County", "Elevation", "Name", "NearestTown" },
                values: new object[,]
                {
                    { 1, "El Paso", 14110, "Pikes Peak", "Colorado Springs" },
                    { 2, "Hinsdale", 14048, "Handies Peak", null },
                    { 3, null, 14270, "Grays Peak", null },
                    { 4, "Clear Creek", 14060, "Mt. Bierstadt", null },
                    { 5, "Summit", 14265, "Quandry Peak", "Breckenridge" },
                    { 6, null, 14267, "Torreys Peak", null },
                    { 7, null, 14148, "Mt. Democrat", null },
                    { 8, "Lake", 14433, "Mt. Elbert", "Leadville" },
                    { 9, "Lake", 14421, "Mt. Massive", "Leadville" },
                    { 10, "Chaffee", 14420, "Mt. Harvard", "Buena Vista" },
                    { 11, null, 14345, "Blanca Peak", "Alamosa" },
                    { 12, null, 14345, "La Plata Peak", "Alamosa" }
                });

            migrationBuilder.InsertData(
                table: "Trail",
                columns: new[] { "Id", "Distance", "Name", "PeakId", "StartingElevation" },
                values: new object[,]
                {
                    { 1, 12f, "Barr Trail", 1, 6650 },
                    { 2, 7f, "Crags", 1, 10000 },
                    { 3, 2.75f, "Southwest", 2, 11600 },
                    { 4, 1.5f, "West", 2, 11300 },
                    { 5, 3.4f, "East Ridge", 5, 10850 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trail_PeakId",
                table: "Trail",
                column: "PeakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trail");

            migrationBuilder.DropTable(
                name: "Peak");
        }
    }
}
