using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Test.Migrations
{
    /// <inheritdoc />
    public partial class darKarteli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Books_BookId",
                table: "Pages");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Books_BookId",
                table: "Pages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Books_BookId",
                table: "Pages");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Books_BookId",
                table: "Pages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
