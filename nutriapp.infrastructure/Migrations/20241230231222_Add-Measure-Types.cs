using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasureTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MeasureType",
                columns: new[] { "Id", "Abbreviation", "ConversionFactor", "Name", "Type" },
                values: new object[,]
                {
                    { 6, "und.", 1.0, "Unidad", "Unidad" },
                    { 7, "cda.", 1.0, "Cuchara", "Cuchara" },
                    { 8, "cta.", 1.0, "Cucharadita", "Cucharadita" },
                    { 9, "reb.", 1.0, "Rebanada", "Rebanada" },
                    { 10, "puño", 1.0, "Puño", "Puño" },
                    { 11, "vaso", 1.0, "Vaso", "Vaso" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
