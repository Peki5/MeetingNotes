using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_notes_var_into_meeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
