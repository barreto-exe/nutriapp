using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMeasureAbbreviation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Abbreviation",
                value: "taza");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Abbreviation",
                value: "copa");
        }
    }
}
