using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class AllowMultipleGamesInTradeOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Games_IdGame",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_IdGame",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IdGame",
                table: "Offers");

            migrationBuilder.CreateTable(
                name: "TradeOfferGames",
                columns: table => new
                {
                    IdTradeOfferGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdOffer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeOfferGames", x => x.IdTradeOfferGame);
                    table.ForeignKey(
                        name: "FK_TradeOfferGames_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeOfferGames_Offers_IdOffer",
                        column: x => x.IdOffer,
                        principalTable: "Offers",
                        principalColumn: "IdOffer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TradeOfferGames",
                columns: new[] { "IdTradeOfferGame", "IdGame", "IdOffer" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "TradeOfferGames",
                columns: new[] { "IdTradeOfferGame", "IdGame", "IdOffer" },
                values: new object[] { 2, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TradeOfferGames_IdGame",
                table: "TradeOfferGames",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_TradeOfferGames_IdOffer",
                table: "TradeOfferGames",
                column: "IdOffer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeOfferGames");

            migrationBuilder.AddColumn<int>(
                name: "IdGame",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "IdOffer",
                keyValue: 1,
                column: "IdGame",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdGame",
                table: "Offers",
                column: "IdGame");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Games_IdGame",
                table: "Offers",
                column: "IdGame",
                principalTable: "Games",
                principalColumn: "IdGame",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
