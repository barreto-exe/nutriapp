using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMeasureTypeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "MeasureType",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ConversionFactor",
                table: "MeasureType",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MeasureType",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "MeasureType",
                columns: new[] { "Id", "Abbreviation", "ConversionFactor", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "gr.", 1.0, "Gramo", "Masa" },
                    { 2, "kg.", 1000.0, "Kilogramo", "Masa" },
                    { 3, "lt.", 1.0, "Litro", "Capacidad" },
                    { 4, "ml.", 1000.0, "Mililitro", "Capacidad" },
                    { 5, "copa", 1.0, "Taza", "Taza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MeasureType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "MeasureType");

            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                table: "MeasureType");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MeasureType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldDefaultValue: "");
        }
    }
}
