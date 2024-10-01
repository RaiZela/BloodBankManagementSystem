using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Donor_Examination_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonorID",
                table: "ExaminationResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationResult_DonorID",
                table: "ExaminationResult",
                column: "DonorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationResult_Donor_DonorID",
                table: "ExaminationResult",
                column: "DonorID",
                principalTable: "Donor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationResult_Donor_DonorID",
                table: "ExaminationResult");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationResult_DonorID",
                table: "ExaminationResult");

            migrationBuilder.DropColumn(
                name: "DonorID",
                table: "ExaminationResult");
        }
    }
}
