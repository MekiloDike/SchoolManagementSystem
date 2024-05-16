using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class removedStudentCourseid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentCourses_StudentCourseId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentCourseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentCourseId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.AddColumn<string>(
                name: "StudentCourseId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentCourseId",
                table: "Courses",
                column: "StudentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentCourses_StudentCourseId",
                table: "Courses",
                column: "StudentCourseId",
                principalTable: "StudentCourses",
                principalColumn: "Id");
        }
    }
}
