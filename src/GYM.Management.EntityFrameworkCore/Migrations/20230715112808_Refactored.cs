using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class Refactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ExerciseCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ExerciseCategories",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ExerciseCategories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ExerciseCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ExerciseCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ExerciseCategories",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "ExerciseCategories",
                type: "uuid",
                nullable: true);
        }
    }
}
