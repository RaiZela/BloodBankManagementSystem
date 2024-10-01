using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasurement_in_ReferenceValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceValue_Examination_ExaminationID",
                table: "ReferenceValue");

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "ReferenceValue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasurementID",
                table: "ReferenceValue",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_ReferenceValue_UnitOfMeasurementID",
                table: "ReferenceValue",
                column: "UnitOfMeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceValue_Examination_ExaminationID",
                table: "ReferenceValue",
                column: "ExaminationID",
                principalTable: "Examination",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceValue_UnitOfMeasurement_UnitOfMeasurementID",
                table: "ReferenceValue",
                column: "UnitOfMeasurementID",
                principalTable: "UnitOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceValue_Examination_ExaminationID",
                table: "ReferenceValue");

            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceValue_UnitOfMeasurement_UnitOfMeasurementID",
                table: "ReferenceValue");

            migrationBuilder.DropIndex(
                name: "IX_ReferenceValue_UnitOfMeasurementID",
                table: "ReferenceValue");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "ReferenceValue");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasurementID",
                table: "ReferenceValue");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceValue_Examination_ExaminationID",
                table: "ReferenceValue",
                column: "ExaminationID",
                principalTable: "Examination",
                principalColumn: "ID");
        }
    }
}
