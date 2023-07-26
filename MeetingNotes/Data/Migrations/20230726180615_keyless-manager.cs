using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class keylessmanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cbefb56-1273-42b9-b8c0-6b59b59f8a48", "AQAAAAIAAYagAAAAEAx/QNhb7mdbpL8tvjVploorMcJXCyJj6n/6/QVFjWLhnLPYhZPWfL+jo4y99U0vOQ==", "eb3e01e6-7cbe-419c-85e9-337fd71e30a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Manager",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                columns: new[] { "ManagerId", "WorkerId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2fe480a-9b9e-473d-8502-b38c48a516a5", "AQAAAAIAAYagAAAAEHs24y9DBnxcFdWVf0MLOHSnHWQmVcThvW1xRCYLAzkLIW9c3nhbOvKYILkjV/Xgbg==", "15bece05-b69b-4b88-9e3e-a483481db58d" });
        }
    }
}
