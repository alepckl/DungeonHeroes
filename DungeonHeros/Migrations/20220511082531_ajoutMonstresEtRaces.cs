using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DungeonHeros.Migrations
{
    /// <inheritdoc />
    public partial class ajoutMonstresEtRaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Races_RaceId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_RaceId",
                table: "Monsters");

            migrationBuilder.AddColumn<int>(
                name: "isForUser",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "MonsterId", "MonsterName", "RaceId", "Stamina", "Strength" },
                values: new object[,]
                {
                    { 1, "Spider", 6, 2, 2 },
                    { 2, "Ogre", 7, 3, 1 },
                    { 3, "Grougaloragran", 5, 12, 4 },
                    { 4, "Serwaul", 8, 1, 7 },
                    { 5, "Bat", 6, 2, 1 },
                    { 6, "Giant Wolf", 6, 3, 4 },
                    { 7, "Efrit", 7, 4, 4 },
                    { 8, "Bone Golem", 7, 3, 5 },
                    { 9, "Hydra", 7, 11, 5 },
                    { 10, "Kobold", 7, 4, 2 },
                    { 11, "Fafnir", 5, 7, 9 },
                    { 12, "Dark Lord", 8, 20, 20 },
                    { 13, "Vouivre", 5, 15, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1,
                column: "isForUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2,
                column: "isForUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 3,
                column: "isForUser",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 4,
                column: "isForUser",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "isForUser",
                table: "Races");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_RaceId",
                table: "Monsters",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Races_RaceId",
                table: "Monsters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
