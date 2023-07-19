using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_worker_identity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_AspNetUsers_IdentityUserId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_IdentityUserId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Worker",
                newName: "userId");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Worker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_userId",
                table: "Worker",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_AspNetUsers_userId",
                table: "Worker",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_AspNetUsers_userId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_userId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Worker",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Worker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Worker",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_IdentityUserId",
                table: "Worker",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_AspNetUsers_IdentityUserId",
                table: "Worker",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
