using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class separateHeroesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Stamina",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "AspNetUsers",
                newName: "HeroId");

            migrationBuilder.AlterColumn<string>(
                name: "FounderId",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Stamina = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<double>(type: "float", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.HeroId);
                    table.ForeignKey(
                        name: "FK_Hero_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hero_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hero_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_FounderId",
                table: "Teams",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_ClassId",
                table: "Hero",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_RaceId",
                table: "Hero",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_TeamId",
                table: "Hero",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hero_HeroId",
                table: "AspNetUsers",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_FounderId",
                table: "Teams",
                column: "FounderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hero_HeroId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_FounderId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropIndex(
                name: "IX_Teams_FounderId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "AspNetUsers",
                newName: "Strength");

            migrationBuilder.AlterColumn<string>(
                name: "FounderId",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Level",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stamina",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    EntitiesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.EntitiesId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_TeamUser_AspNetUsers_EntitiesId",
                        column: x => x.EntitiesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamUser_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_TeamsTeamId",
                table: "TeamUser",
                column: "TeamsTeamId");
        }
    }
}
