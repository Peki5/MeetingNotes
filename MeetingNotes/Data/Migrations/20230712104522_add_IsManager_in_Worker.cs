using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_IsManager_in_Worker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "Worker",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Worker");
        }
    }
}
