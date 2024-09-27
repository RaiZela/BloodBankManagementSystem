using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Donor_AuditableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_DeletedDonors_DeletedDonorsID",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_SuspensionReason_DeletedDonors_DeletedDonorsID",
                table: "SuspensionReason");

            migrationBuilder.DropTable(
                name: "DeletedDonors");

            migrationBuilder.DropIndex(
                name: "IX_SuspensionReason_DeletedDonorsID",
                table: "SuspensionReason");

            migrationBuilder.DropIndex(
                name: "IX_Donation_DeletedDonorsID",
                table: "Donation");

            migrationBuilder.DropColumn(
                name: "DeletedDonorsID",
                table: "SuspensionReason");

            migrationBuilder.DropColumn(
                name: "DeletedDonorsID",
                table: "Donation");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Donor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Donor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb35e660-f77a-4406-be32-449b4b45f313", "AQAAAAIAAYagAAAAEAeMKhluM3VvaYYCnEJiF6/pQnezvj92ZgtDbMW0y63hmYNW4PiKlMz3qXq1MmrKVQ==", "7f3c1f88-5f79-4d03-8fa6-484a0dba8c11" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Donor");

            migrationBuilder.AddColumn<int>(
                name: "DeletedDonorsID",
                table: "SuspensionReason",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedDonorsID",
                table: "Donation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DeletedDonors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DonorID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedDonors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeletedDonors_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7884d5f0-114a-4d6b-877e-30c92f27a439", "AQAAAAIAAYagAAAAEJ5uPJxBGDyHYvXDHq0E7EF3QugpVpcPF1mpgMz354mv+XKUdjo+o5l2PwqT3kHrQA==", "aaffefef-db76-43b5-baa0-4bf497dc62f5" });

            migrationBuilder.CreateIndex(
                name: "IX_SuspensionReason_DeletedDonorsID",
                table: "SuspensionReason",
                column: "DeletedDonorsID");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_DeletedDonorsID",
                table: "Donation",
                column: "DeletedDonorsID");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedDonors_CityID",
                table: "DeletedDonors",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_DeletedDonors_DeletedDonorsID",
                table: "Donation",
                column: "DeletedDonorsID",
                principalTable: "DeletedDonors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SuspensionReason_DeletedDonors_DeletedDonorsID",
                table: "SuspensionReason",
                column: "DeletedDonorsID",
                principalTable: "DeletedDonors",
                principalColumn: "ID");
        }
    }
}
