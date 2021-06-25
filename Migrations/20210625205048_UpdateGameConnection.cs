using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class UpdateGameConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGameCanBeTradedFors_Games_IdAdvert",
                table: "AdvertGameCanBeTradedFors");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertGameCanBeTradedFors_IdGame",
                table: "AdvertGameCanBeTradedFors",
                column: "IdGame");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGameCanBeTradedFors_Games_IdGame",
                table: "AdvertGameCanBeTradedFors",
                column: "IdGame",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGameCanBeTradedFors_Games_IdGame",
                table: "AdvertGameCanBeTradedFors");

            migrationBuilder.DropIndex(
                name: "IX_AdvertGameCanBeTradedFors_IdGame",
                table: "AdvertGameCanBeTradedFors");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGameCanBeTradedFors_Games_IdAdvert",
                table: "AdvertGameCanBeTradedFors",
                column: "IdAdvert",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
