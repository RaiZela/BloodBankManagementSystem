using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ResponseLogicFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnswerID",
                table: "Response",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Response",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed03ee9-013d-4030-a18e-7fbe17db8a76", "AQAAAAIAAYagAAAAEIoKx7cKXKd/nYfw/sOny5/qgPHSPWp1rXh21V16xHXoyoiNhM72n3vPvrt+9SiMuA==", "f3e87afc-e93e-4336-86f4-eafdd6fb465c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Response");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerID",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb35e660-f77a-4406-be32-449b4b45f313", "AQAAAAIAAYagAAAAEAeMKhluM3VvaYYCnEJiF6/pQnezvj92ZgtDbMW0y63hmYNW4PiKlMz3qXq1MmrKVQ==", "7f3c1f88-5f79-4d03-8fa6-484a0dba8c11" });
        }
    }
}
