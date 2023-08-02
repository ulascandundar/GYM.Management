using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class TrainerAddedToIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "AbpUsers",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AbpUsers");
        }
    }
}
