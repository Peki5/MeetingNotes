using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class partial_primary_key_manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2fe480a-9b9e-473d-8502-b38c48a516a5", "AQAAAAIAAYagAAAAEHs24y9DBnxcFdWVf0MLOHSnHWQmVcThvW1xRCYLAzkLIW9c3nhbOvKYILkjV/Xgbg==", "15bece05-b69b-4b88-9e3e-a483481db58d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "150e3d91-b30c-4080-8f22-d87f47e58363", "AQAAAAIAAYagAAAAEC4/ulszc8XTqk/ilIjNMFXC5riARxZ+7v90V9y5L0PVK3j6RPCw1NgAGnIsWlE+vg==", "1cddc618-dceb-47ac-99ae-f15ad3d9585f" });
        }
    }
}
