using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class ajoutTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DungeonTeam_Team_TeamFightersTeamId",
                table: "DungeonTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_Team_TeamsTeamId",
                table: "TeamUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DungeonTeam_Teams_TeamFightersTeamId",
                table: "DungeonTeam",
                column: "TeamFightersTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_Teams_TeamsTeamId",
                table: "TeamUser",
                column: "TeamsTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DungeonTeam_Teams_TeamFightersTeamId",
                table: "DungeonTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUser_Teams_TeamsTeamId",
                table: "TeamUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DungeonTeam_Team_TeamFightersTeamId",
                table: "DungeonTeam",
                column: "TeamFightersTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUser_Team_TeamsTeamId",
                table: "TeamUser",
                column: "TeamsTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
