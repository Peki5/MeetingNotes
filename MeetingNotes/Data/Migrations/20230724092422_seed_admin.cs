using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class seed_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "012345f0-akl2–42de-afbf-59ccfdaf72cf6", "012345f0-akl2–42de-afbf-59ccfdaf72cf6", "Worker", "WORKER" },
                    { "341743f0-a67k–42de-afbf-59asdfac72cf6", "341743f0-a67k–42de-afbf-59asdfac72cf6", "Manager", "MANAGER" },
                    { "74d04fa7-36b6-4fa2-ade4-d2a1759e4091", "74d04fa7-36b6-4fa2-ade4-d2a1759e4091", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22e40406-8a9d-2d82-912c-5d6a640ee696", 0, "ffef1c15-0620-4d23-aded-bc45e3c98f0d", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHJZhEgdBN3J/tS7yabS7WIhiArxvNnrgrMRStBbRhd4lulJBDhREFmFHbwvGkEmiQ==", null, false, "1b46dfc0-7326-464d-9f95-e760f4b6dfe2", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "74d04fa7-36b6-4fa2-ade4-d2a1759e4091", "22e40406-8a9d-2d82-912c-5d6a640ee696" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "012345f0-akl2–42de-afbf-59ccfdaf72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-a67k–42de-afbf-59asdfac72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74d04fa7-36b6-4fa2-ade4-d2a1759e4091", "22e40406-8a9d-2d82-912c-5d6a640ee696" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74d04fa7-36b6-4fa2-ade4-d2a1759e4091");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696");
        }
    }
}
