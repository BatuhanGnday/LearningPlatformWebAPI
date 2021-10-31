using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace LearningPlatformWebAPI.Migrations
{
    public partial class Migration101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Courses",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Courses",
                newName: "EndTime");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<LocalDate>(
                name: "ValidAfter",
                table: "Courses",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<LocalDate>(
                name: "ValidUntil",
                table: "Courses",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classrooms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ValidAfter",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ValidUntil",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Courses",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Courses",
                newName: "End");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Classrooms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
