using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_WorkerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Worker",
                newName: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Worker",
                newName: "Id");
        }
    }
}
