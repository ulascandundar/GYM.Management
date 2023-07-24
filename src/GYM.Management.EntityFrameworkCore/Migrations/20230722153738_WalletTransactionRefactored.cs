using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class WalletTransactionRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "WalletTransactions",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "WalletTransactions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "WalletTransactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "WalletTransactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "WalletTransactions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "WalletTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WalletTransactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "WalletTransactions",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "WalletTransactions",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "WalletTransactions");
        }
    }
}
