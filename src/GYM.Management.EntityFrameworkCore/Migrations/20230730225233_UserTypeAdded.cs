using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class UserTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AbpUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AbpUsers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AbpUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "AbpUsers",
                type: "uuid",
                nullable: true);
        }
    }
}
