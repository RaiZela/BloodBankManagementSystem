using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ResponseValueNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69e4a3ce-8242-46b5-bdae-1b0423679169", "AQAAAAIAAYagAAAAEPNBteJloyfkmFpsUfK6h7L5vEQq5YEC4vZW4nrLIjLj1WW2auL5j6xy/pDs4WLKZQ==", "f5448c85-e206-4a07-866b-161825012651" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Response",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed03ee9-013d-4030-a18e-7fbe17db8a76", "AQAAAAIAAYagAAAAEIoKx7cKXKd/nYfw/sOny5/qgPHSPWp1rXh21V16xHXoyoiNhM72n3vPvrt+9SiMuA==", "f3e87afc-e93e-4336-86f4-eafdd6fb465c" });
        }
    }
}
