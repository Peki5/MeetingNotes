using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_worker_password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec3cefb0-f67f-4845-8136-c80e0ea9999e", "AQAAAAIAAYagAAAAELxJHc+Vms7BaAUUcznQPBDcgpD3AAmafRnVN781NvfTz/pinau9UAnYKNz55fc/5Q==", "c0adf274-5854-4ca5-bf09-4ba2e7338237" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffef1c15-0620-4d23-aded-bc45e3c98f0d", "AQAAAAIAAYagAAAAEHJZhEgdBN3J/tS7yabS7WIhiArxvNnrgrMRStBbRhd4lulJBDhREFmFHbwvGkEmiQ==", "1b46dfc0-7326-464d-9f95-e760f4b6dfe2" });
        }
    }
}
