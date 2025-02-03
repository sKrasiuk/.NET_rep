using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Atsiskaitymas.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Students_StudentsId",
                table: "LectureStudent");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "LectureStudent",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "LectureStudent",
                newName: "Lecture");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_StudentsId",
                table: "LectureStudent",
                newName: "IX_LectureStudent_Student");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "DepartmentLecture",
                newName: "Lecture");

            migrationBuilder.AddColumn<int>(
                name: "Student",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Student",
                table: "Students",
                column: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_Lecture",
                table: "DepartmentLecture",
                column: "Lecture",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_Student",
                table: "LectureStudent",
                column: "Student",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Students_Lecture",
                table: "LectureStudent",
                column: "Lecture",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Student",
                table: "Students",
                column: "Student",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Departments_Lecture",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_Student",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Students_Lecture",
                table: "LectureStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Student",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Student",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Student",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Student",
                table: "LectureStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "Lecture",
                table: "LectureStudent",
                newName: "LecturesId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureStudent_Student",
                table: "LectureStudent",
                newName: "IX_LectureStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "Lecture",
                table: "DepartmentLecture",
                newName: "DepartmentsId");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Departments_DepartmentsId",
                table: "DepartmentLecture",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Students_StudentsId",
                table: "LectureStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
