using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallLeague.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoachesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurnameOfPlayer",
                table: "Coaches",
                newName: "SurnameOfCoach");

            migrationBuilder.RenameColumn(
                name: "NameOfPlayer",
                table: "Coaches",
                newName: "NameOfCoach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurnameOfCoach",
                table: "Coaches",
                newName: "SurnameOfPlayer");

            migrationBuilder.RenameColumn(
                name: "NameOfCoach",
                table: "Coaches",
                newName: "NameOfPlayer");
        }
    }
}
