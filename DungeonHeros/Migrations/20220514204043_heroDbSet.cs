using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class heroDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hero_HeroForeignKey",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Classes_ClassId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Races_RaceId",
                table: "Hero");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_Teams_TeamId",
                table: "Hero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero",
                table: "Hero");

            migrationBuilder.DropIndex(
                name: "IX_Hero_TeamId",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Hero");

            migrationBuilder.RenameTable(
                name: "Hero",
                newName: "Heroes");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_RaceId",
                table: "Heroes",
                newName: "IX_Heroes_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_ClassId",
                table: "Heroes",
                newName: "IX_Heroes_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "HeroId");

            migrationBuilder.CreateTable(
                name: "HeroTeam",
                columns: table => new
                {
                    HeroesHeroId = table.Column<int>(type: "int", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTeam", x => new { x.HeroesHeroId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_HeroTeam_Heroes_HeroesHeroId",
                        column: x => x.HeroesHeroId,
                        principalTable: "Heroes",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroTeam_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroTeam_TeamsTeamId",
                table: "HeroTeam",
                column: "TeamsTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Heroes_HeroForeignKey",
                table: "AspNetUsers",
                column: "HeroForeignKey",
                principalTable: "Heroes",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Classes_ClassId",
                table: "Heroes",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Races_RaceId",
                table: "Heroes",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Heroes_HeroForeignKey",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Classes_ClassId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Races_RaceId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "HeroTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "Hero");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_RaceId",
                table: "Hero",
                newName: "IX_Hero_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_ClassId",
                table: "Hero",
                newName: "IX_Hero_ClassId");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Hero",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero",
                table: "Hero",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_TeamId",
                table: "Hero",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hero_HeroForeignKey",
                table: "AspNetUsers",
                column: "HeroForeignKey",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Classes_ClassId",
                table: "Hero",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Races_RaceId",
                table: "Hero",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_Teams_TeamId",
                table: "Hero",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }
    }
}
