using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class SafeRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Safes",
                newName: "Balance");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SafeTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SafeTransactions");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Safes",
                newName: "Amount");
        }
    }
}
