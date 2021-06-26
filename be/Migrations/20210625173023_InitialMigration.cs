using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    IdGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    IdAdvert = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IdSeller = table.Column<int>(type: "int", nullable: false),
                    UserIdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.IdAdvert);
                    table.ForeignKey(
                        name: "FK_Adverts_Users_IdSeller",
                        column: x => x.IdSeller,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_Adverts_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvertGameCanBeTradedFors",
                columns: table => new
                {
                    IdAdvertGameCanBeTradedFor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdvert = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertGameCanBeTradedFors", x => x.IdAdvertGameCanBeTradedFor);
                    table.ForeignKey(
                        name: "FK_AdvertGameCanBeTradedFors_Adverts_IdAdvert",
                        column: x => x.IdAdvert,
                        principalTable: "Adverts",
                        principalColumn: "IdAdvert",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertGameCanBeTradedFors_Games_IdAdvert",
                        column: x => x.IdAdvert,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertGameSubjects",
                columns: table => new
                {
                    IdAdvertGameSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdvert = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertGameSubjects", x => x.IdAdvertGameSubject);
                    table.ForeignKey(
                        name: "FK_AdvertGameSubjects_Adverts_IdAdvert",
                        column: x => x.IdAdvert,
                        principalTable: "Adverts",
                        principalColumn: "IdAdvert",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertGameSubjects_Games_IdAdvert",
                        column: x => x.IdAdvert,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    IdOffer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBuyer = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAdvert = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: true),
                    IdGame = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.IdOffer);
                    table.ForeignKey(
                        name: "FK_Offers_Adverts_IdAdvert",
                        column: x => x.IdAdvert,
                        principalTable: "Adverts",
                        principalColumn: "IdAdvert",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Users_IdBuyer",
                        column: x => x.IdBuyer,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "IdGame", "CoverPhoto", "Description", "Title" },
                values: new object[,]
                {
                    { 1, null, "Description 1", "Game 1" },
                    { 2, null, "Description 2", "Game 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "CreationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "IdAdvert", "CreationDate", "Description", "IdSeller", "IsActive", "UserIdUser" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 1", 2, true, null });

            migrationBuilder.InsertData(
                table: "AdvertGameCanBeTradedFors",
                columns: new[] { "IdAdvertGameCanBeTradedFor", "IdAdvert", "IdGame" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "AdvertGameSubjects",
                columns: new[] { "IdAdvertGameSubject", "IdAdvert", "IdGame" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "IdOffer", "CreationDate", "Discriminator", "IdAdvert", "IdBuyer", "Price" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BuyoutOffer", 1, 1, 20f });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "IdOffer", "CreationDate", "Discriminator", "IdAdvert", "IdBuyer", "IdGame" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TradeOffer", 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertGameCanBeTradedFors_IdAdvert",
                table: "AdvertGameCanBeTradedFors",
                column: "IdAdvert");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertGameSubjects_IdAdvert",
                table: "AdvertGameSubjects",
                column: "IdAdvert");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_IdSeller",
                table: "Adverts",
                column: "IdSeller");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserIdUser",
                table: "Adverts",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdAdvert",
                table: "Offers",
                column: "IdAdvert");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdBuyer",
                table: "Offers",
                column: "IdBuyer");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdGame",
                table: "Offers",
                column: "IdGame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertGameCanBeTradedFors");

            migrationBuilder.DropTable(
                name: "AdvertGameSubjects");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
