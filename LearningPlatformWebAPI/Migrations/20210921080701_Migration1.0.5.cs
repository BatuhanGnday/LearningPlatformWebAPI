using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningPlatformWebAPI.Migrations
{
    public partial class Migration105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int[]>(
                name: "DayOfWeek",
                table: "Courses",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
