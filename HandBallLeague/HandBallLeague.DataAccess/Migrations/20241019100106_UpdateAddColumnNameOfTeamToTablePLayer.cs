using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallLeague.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddColumnNameOfTeamToTablePLayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOfTeam",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfTeam",
                table: "Players");
        }
    }
}
