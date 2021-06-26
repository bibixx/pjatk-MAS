using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class AddTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTransaction",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CollectionMethods",
                columns: table => new
                {
                    IdCollectionMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedPickupDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMethods", x => x.IdCollectionMethod);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    IdPaymentMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.IdPaymentMethod);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    IdTransaction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCollectionMethod = table.Column<int>(type: "int", nullable: false),
                    IdPaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transactions_CollectionMethods_IdCollectionMethod",
                        column: x => x.IdCollectionMethod,
                        principalTable: "CollectionMethods",
                        principalColumn: "IdCollectionMethod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentMethods_IdPaymentMethod",
                        column: x => x.IdPaymentMethod,
                        principalTable: "PaymentMethods",
                        principalColumn: "IdPaymentMethod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_IdTransaction",
                table: "Offers",
                column: "IdTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdCollectionMethod",
                table: "Transactions",
                column: "IdCollectionMethod");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IdPaymentMethod",
                table: "Transactions",
                column: "IdPaymentMethod");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Transactions_IdTransaction",
                table: "Offers",
                column: "IdTransaction",
                principalTable: "Transactions",
                principalColumn: "IdTransaction",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Transactions_IdTransaction",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CollectionMethods");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Offers_IdTransaction",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IdTransaction",
                table: "Offers");
        }
    }
}
