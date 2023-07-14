using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_NotesId_from_Meeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Notes_NotesId1",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_NotesId1",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "NotesId1",
                table: "Meeting");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Notes",
                newName: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_MeetingId",
                table: "Notes",
                column: "MeetingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Meeting_MeetingId",
                table: "Notes",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Meeting_MeetingId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_MeetingId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "Notes",
                newName: "ManagerId");

            migrationBuilder.AddColumn<int>(
                name: "NotesId1",
                table: "Meeting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_NotesId1",
                table: "Meeting",
                column: "NotesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Notes_NotesId1",
                table: "Meeting",
                column: "NotesId1",
                principalTable: "Notes",
                principalColumn: "NotesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
