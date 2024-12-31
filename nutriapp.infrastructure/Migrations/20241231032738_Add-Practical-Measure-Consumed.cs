using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPracticalMeasureConsumed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Units",
                table: "FoodConsumed",
                newName: "PracticalMeasureType");

            migrationBuilder.RenameColumn(
                name: "Cups",
                table: "FoodConsumed",
                newName: "PracticalQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumed_PracticalMeasureType",
                table: "FoodConsumed",
                column: "PracticalMeasureType");

            migrationBuilder.AddForeignKey(
                name: "FK__FoodConsu__Pract__04E4BC85",
                table: "FoodConsumed",
                column: "PracticalMeasureType",
                principalTable: "MeasureType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FoodConsu__Pract__04E4BC85",
                table: "FoodConsumed");

            migrationBuilder.DropIndex(
                name: "IX_FoodConsumed_PracticalMeasureType",
                table: "FoodConsumed");

            migrationBuilder.RenameColumn(
                name: "PracticalQuantity",
                table: "FoodConsumed",
                newName: "Cups");

            migrationBuilder.RenameColumn(
                name: "PracticalMeasureType",
                table: "FoodConsumed",
                newName: "Units");
        }
    }
}
