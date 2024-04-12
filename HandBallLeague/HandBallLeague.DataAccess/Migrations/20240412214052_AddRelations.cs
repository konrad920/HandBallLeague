using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallLeague.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachDBId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamDBId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamDBId",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchDBTeamDB",
                columns: table => new
                {
                    MatchesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDBTeamDB", x => new { x.MatchesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_MatchDBTeamDB_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchDBTeamDB_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamDBId",
                table: "Players",
                column: "TeamDBId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDBTeamDB_TeamsId",
                table: "MatchDBTeamDB",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamDBId",
                table: "Players",
                column: "TeamDBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamDBId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "MatchDBTeamDB");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamDBId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CoachDBId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamDBId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamDBId",
                table: "Coaches");
        }
    }
}
