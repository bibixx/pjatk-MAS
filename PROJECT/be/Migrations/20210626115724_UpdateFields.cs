using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGameSubjects_Games_IdAdvert",
                table: "AdvertGameSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertGameSubjects_IdGame",
                table: "AdvertGameSubjects",
                column: "IdGame");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGameSubjects_Games_IdGame",
                table: "AdvertGameSubjects",
                column: "IdGame",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertGameSubjects_Games_IdGame",
                table: "AdvertGameSubjects");

            migrationBuilder.DropIndex(
                name: "IX_AdvertGameSubjects_IdGame",
                table: "AdvertGameSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertGameSubjects_Games_IdAdvert",
                table: "AdvertGameSubjects",
                column: "IdAdvert",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
