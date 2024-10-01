using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceValue_IsEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ReferenceValue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "7fbe478a-9ebd-4923-93b3-af9087cf794c", "AQAAAAIAAYagAAAAEBUOrTTBNY0cuutw1yglN+QG/tdmOMPFIYMABotOXkEeXv8nRclJRyPmdu0N7Yq5Cw==", "4fe8d9dd-d139-4e3d-abe8-4df4c48fbf34" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ReferenceValue");

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "69e4a3ce-8242-46b5-bdae-1b0423679169", "AQAAAAIAAYagAAAAEPNBteJloyfkmFpsUfK6h7L5vEQq5YEC4vZW4nrLIjLj1WW2auL5j6xy/pDs4WLKZQ==", "f5448c85-e206-4a07-866b-161825012651" });
        }
    }
}
