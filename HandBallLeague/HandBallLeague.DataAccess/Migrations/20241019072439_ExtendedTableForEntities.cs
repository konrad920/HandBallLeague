using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallLeague.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedTableForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachDBId",
                table: "Teams");

            migrationBuilder.AddColumn<float>(
                name: "BudgetOfTeam",
                table: "Teams",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "GuestsTeamId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HostsTeamId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamDBId",
                table: "Coaches",
                column: "TeamDBId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamDBId",
                table: "Coaches",
                column: "TeamDBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_TeamDBId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_TeamDBId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "BudgetOfTeam",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GuestsTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HostsTeamId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "CoachDBId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
