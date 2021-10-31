using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningPlatformWebAPI.Migrations
{
    public partial class Migration104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "DayOfWeek",
                table: "Courses",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Courses");
        }
    }
}
