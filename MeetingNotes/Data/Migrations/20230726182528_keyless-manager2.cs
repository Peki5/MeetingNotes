using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class keylessmanager2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d74c7026-ac91-484c-8502-5b02523c5852", "AQAAAAIAAYagAAAAEHUtRjMMtWFQ/w8rtROLkEV4HJoq/j1tDabNaHTKidWUUFlLj3B06at7eUEZ9cmmvw==", "a50c8215-e497-4b29-a27d-d550b36b3360" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cbefb56-1273-42b9-b8c0-6b59b59f8a48", "AQAAAAIAAYagAAAAEAx/QNhb7mdbpL8tvjVploorMcJXCyJj6n/6/QVFjWLhnLPYhZPWfL+jo4y99U0vOQ==", "eb3e01e6-7cbe-419c-85e9-337fd71e30a0" });
        }
    }
}
