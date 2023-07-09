using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_Worker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Worker");

            migrationBuilder.AddColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Worker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Worker",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Worker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_IdentityUserId",
                table: "Worker",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_AspNetUsers_IdentityUserId",
                table: "Worker",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_AspNetUsers_IdentityUserId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_IdentityUserId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Worker");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
