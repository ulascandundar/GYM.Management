﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class SafeAmountAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SafeAmount",
                table: "Debts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SafeAmount",
                table: "Debts");
        }
    }
}
