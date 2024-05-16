using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class TeacherStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudentCourse");

            migrationBuilder.DropTable(
                name: "StudentTeacherStudent");

            migrationBuilder.DropTable(
                name: "TeacherTeacherStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherStudent",
                table: "TeacherStudent");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "TeacherStudent",
                newName: "TeacherStudents");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "TeacherStudents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "TeacherStudents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherStudents",
                table: "TeacherStudents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_TeacherId",
                table: "TeacherStudents",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Students_StudentId",
                table: "TeacherStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherStudents_Teachers_TeacherId",
                table: "TeacherStudents",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Students_StudentId",
                table: "TeacherStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherStudents_Teachers_TeacherId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherStudents",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents");

            migrationBuilder.DropIndex(
                name: "IX_TeacherStudents_TeacherId",
                table: "TeacherStudents");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "TeacherStudents");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherStudents");

            migrationBuilder.RenameTable(
                name: "TeacherStudents",
                newName: "TeacherStudent");

            migrationBuilder.AddColumn<string>(
                name: "TeacherStudentId",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCourseId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherStudentId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherStudent",
                table: "TeacherStudent",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentStudentCourse",
                columns: table => new
                {
                    StudentCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentCourse", x => new { x.StudentCourseId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentStudentCourse_StudentCourses_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "StudentCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentCourse_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacherStudent",
                columns: table => new
                {
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacherStudent", x => new { x.StudentsId, x.TeacherStudentId });
                    table.ForeignKey(
                        name: "FK_StudentTeacherStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacherStudent_TeacherStudent_TeacherStudentId",
                        column: x => x.TeacherStudentId,
                        principalTable: "TeacherStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTeacherStudent",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTeacherStudent", x => new { x.CourseId, x.TeacherStudentId });
                    table.ForeignKey(
                        name: "FK_TeacherTeacherStudent_Teachers_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherTeacherStudent_TeacherStudent_TeacherStudentId",
                        column: x => x.TeacherStudentId,
                        principalTable: "TeacherStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentCourse_StudentsId",
                table: "StudentStudentCourse",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacherStudent_TeacherStudentId",
                table: "StudentTeacherStudent",
                column: "TeacherStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTeacherStudent_TeacherStudentId",
                table: "TeacherTeacherStudent",
                column: "TeacherStudentId");
        }
    }
}
