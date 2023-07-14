using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_ManagerId_into_Notes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Notes");
        }
    }
}
