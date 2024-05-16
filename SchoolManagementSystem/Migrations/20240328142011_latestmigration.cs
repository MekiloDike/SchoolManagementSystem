using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    public partial class latestmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "SchoolType",
                table: "Schools",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "SchoolType",
                table: "Teachers",
                type: "int",
                nullable: true);
        }
    }
}
