using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class TeacherStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_AddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentCourses_StudentCourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Students_StudentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StudentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "TeacherStudentId",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentCourseId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherStudentId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "TeacherStudent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudent", x => x.Id);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudentCourse");

            migrationBuilder.DropTable(
                name: "StudentTeacherStudent");

            migrationBuilder.DropTable(
                name: "TeacherTeacherStudent");

            migrationBuilder.DropTable(
                name: "TeacherStudent");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentCourseId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StudentId",
                table: "Teachers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentCourseId",
                table: "Students",
                column: "StudentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentCourses_StudentCourseId",
                table: "Students",
                column: "StudentCourseId",
                principalTable: "StudentCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Students_StudentId",
                table: "Teachers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
