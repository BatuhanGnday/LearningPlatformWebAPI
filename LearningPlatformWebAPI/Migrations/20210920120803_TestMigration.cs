using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace LearningPlatformWebAPI.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Permissions = table.Column<int[]>(type: "integer[]", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ClassroomGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Start = table.Column<LocalTime>(type: "time", nullable: false),
                    End = table.Column<LocalTime>(type: "time", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Courses_Classrooms_ClassroomGuid",
                        column: x => x.ClassroomGuid,
                        principalTable: "Classrooms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomUser",
                columns: table => new
                {
                    ClassroomsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomUser", x => new { x.ClassroomsGuid, x.ParticipantsGuid });
                    table.ForeignKey(
                        name: "FK_ClassroomUser_Classrooms_ClassroomsGuid",
                        column: x => x.ClassroomsGuid,
                        principalTable: "Classrooms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomUser_Users_ParticipantsGuid",
                        column: x => x.ParticipantsGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassroomGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Start = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    End = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Exams_Classrooms_ClassroomGuid",
                        column: x => x.ClassroomGuid,
                        principalTable: "Classrooms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Users_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRole",
                columns: table => new
                {
                    RolesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRole", x => new { x.RolesGuid, x.UsersGuid });
                    table.ForeignKey(
                        name: "FK_UserUserRole_UserRoles_RolesGuid",
                        column: x => x.RolesGuid,
                        principalTable: "UserRoles",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRole_Users_UsersGuid",
                        column: x => x.UsersGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: true),
                    ExamGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamGuid",
                        column: x => x.ExamGuid,
                        principalTable: "Exams",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoices",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    IsTrue = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<LocalDateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoices", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_QuestionChoices_Questions_QuestionGuid",
                        column: x => x.QuestionGuid,
                        principalTable: "Questions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomUser_ParticipantsGuid",
                table: "ClassroomUser",
                column: "ParticipantsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassroomGuid",
                table: "Courses",
                column: "ClassroomGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ClassroomGuid",
                table: "Exams",
                column: "ClassroomGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedByGuid",
                table: "Exams",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoices_QuestionGuid",
                table: "QuestionChoices",
                column: "QuestionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamGuid",
                table: "Questions",
                column: "ExamGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_UsersGuid",
                table: "UserUserRole",
                column: "UsersGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomUser");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "QuestionChoices");

            migrationBuilder.DropTable(
                name: "UserUserRole");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
