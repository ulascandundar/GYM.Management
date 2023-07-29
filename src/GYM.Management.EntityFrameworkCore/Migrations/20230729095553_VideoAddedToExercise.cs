using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Management.Migrations
{
    /// <inheritdoc />
    public partial class VideoAddedToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Exercises",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Exercises");
        }
    }
}
