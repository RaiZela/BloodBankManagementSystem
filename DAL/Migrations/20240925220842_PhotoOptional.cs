using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PhotoOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoBase64",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhotoBase64", "SecurityStamp", "Status", "UserName" },
                values: new object[] { "339a8b9a-b650-40c9-ac32-4a7363b77519", "RAIZELA@GMAIL.COM", "AQAAAAIAAYagAAAAENiIvHBhFi5mFthUsWr1nd0haS/lrHfakQmbPvNbzi0OrVGsOU41O3XgRXaP4UxZpA==", null, "46930fff-778f-4681-bf76-d8f0a6359f03", 0, "raizela@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoBase64",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5421a180-0827-4e44-9d84-67777accec2c", "FRANKOFOEDU@GMAIL.COM", "AQAAAAIAAYagAAAAEM0InmaDhPXIyeDj7izX6lsDJREGbEE7SSBD+1uHyhZA2zg2lcXhM1/7b2XxT7JGRg==", "56c23219-312d-47ff-9d14-fcf131ec961a", "frankofoedu@gmail.com" });
        }
    }
}
