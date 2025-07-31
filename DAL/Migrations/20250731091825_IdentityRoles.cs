using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuspensionReason_Donor_DonorID",
                table: "SuspensionReason");

            migrationBuilder.DropIndex(
                name: "IX_SuspensionReason_DonorID",
                table: "SuspensionReason");

            migrationBuilder.DropColumn(
                name: "DonorID",
                table: "SuspensionReason");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDonations",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NumberOfDonations", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "55b6ba05-25a3-4f47-b657-6cdf1f3b7bf5", 0, "AQAAAAIAAYagAAAAEDg1ZV+0z5r0mq8AWYvImJy69MjzeuC0a2g30j6JGKxn1u7fzMkQwvsdRAg20/sA4w==", null, "3466fb26-0d41-4d4c-9be1-1444f7717c88" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumberOfDonations",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DonorID",
                table: "SuspensionReason",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa38fbf-f15d-4938-a4d1-b6380896e584", "AQAAAAIAAYagAAAAEKv3l/Sqe6Z1iJYH+NE9sdVzxPsFrogdgoCBDBsOgeVEas2oJ2e4UNVHc6f9UPotfA==", "f15e8d82-2b52-4cf0-9111-d091a1dbc27b" });

            migrationBuilder.CreateIndex(
                name: "IX_SuspensionReason_DonorID",
                table: "SuspensionReason",
                column: "DonorID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspensionReason_Donor_DonorID",
                table: "SuspensionReason",
                column: "DonorID",
                principalTable: "Donor",
                principalColumn: "ID");
        }
    }
}
