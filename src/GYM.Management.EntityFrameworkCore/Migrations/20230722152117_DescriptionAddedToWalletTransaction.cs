using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionAddedToWalletTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wallets_TrainerId",
                table: "Wallets");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WalletTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_TrainerId",
                table: "Wallets",
                column: "TrainerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wallets_TrainerId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WalletTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_TrainerId",
                table: "Wallets",
                column: "TrainerId");
        }
    }
}
