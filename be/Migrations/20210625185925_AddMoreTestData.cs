using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class AddMoreTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "IdAdvert", "CreationDate", "Description", "GameCondition", "IdSeller", "IsActive", "UserIdUser" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 2", 3, 2, true, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description 3", 1, 2, true, null }
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", "Super Smash Bros: For Wii U" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", "The Elder Scrolls V: Skyrim" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "IdGame", "CoverPhoto", "Description", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 5, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath Of The Wild" },
                    { 20, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summary" },
                    { 19, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" },
                    { 18, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fortnite" },
                    { 17, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V" },
                    { 16, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Clancy’s Rainbow Six Siege" },
                    { 15, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Smash Bros: Ultimate" },
                    { 14, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption II" },
                    { 13, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch" },
                    { 12, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocket League" },
                    { 3, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call of Duty: Black Ops II" },
                    { 10, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "League of Legends" },
                    { 9, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PlayerUnknown’s Battlegrounds (PUBG)" },
                    { 8, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter-Strike: Global Offensive" },
                    { 7, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call of Duty: Black Ops IIII" },
                    { 6, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Odyssey" },
                    { 4, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man (2018)" },
                    { 11, null, "Minima enim distinctio ea excepturi. Maxime ipsa provident consequatur sit non quaerat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roblox" }
                });

            migrationBuilder.InsertData(
                table: "AdvertGameSubjects",
                columns: new[] { "IdAdvertGameSubject", "IdAdvert", "IdGame" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "AdvertGameSubjects",
                columns: new[] { "IdAdvertGameSubject", "IdAdvert", "IdGame" },
                values: new object[] { 3, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdvertGameSubjects",
                keyColumn: "IdAdvertGameSubject",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdvertGameSubjects",
                keyColumn: "IdAdvertGameSubject",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "IdAdvert",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "IdAdvert",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Description 1", "Game 1" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "IdGame",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Description 2", "Game 2" });
        }
    }
}
