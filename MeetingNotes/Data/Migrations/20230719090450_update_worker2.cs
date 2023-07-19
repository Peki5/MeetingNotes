using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_worker2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_AspNetUsers_userId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Worker",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_userId",
                table: "Worker",
                newName: "IX_Worker_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_AspNetUsers_UserId",
                table: "Worker",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_AspNetUsers_UserId",
                table: "Worker");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Worker",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_UserId",
                table: "Worker",
                newName: "IX_Worker_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_AspNetUsers_userId",
                table: "Worker",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
