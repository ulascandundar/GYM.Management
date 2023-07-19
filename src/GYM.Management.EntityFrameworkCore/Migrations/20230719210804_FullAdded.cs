using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class FullAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Trainers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Trainers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Products",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "MemberOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MemberOrders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Member",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Member",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Expenses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Expenses",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Exercises",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Exercises",
                type: "timestamp without time zone",
                nullable: true);

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

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "ExerciseCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ExerciseCategories",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ExerciseCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "MemberOrders");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MemberOrders");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Exercises");

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
                name: "DeleterId",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Categories");
        }
    }
}
