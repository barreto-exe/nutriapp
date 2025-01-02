using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasureColumsFoodAtFridge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "FoodConsumed",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureType",
                table: "FoodConsumed",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FoodAtFridge",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "FoodAtFridge",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureType",
                table: "FoodAtFridge",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CookedMeasureType",
                table: "FoodAtFridge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CookedQuantity",
                table: "FoodAtFridge",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PracticalMeasureType",
                table: "FoodAtFridge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PracticalQuantity",
                table: "FoodAtFridge",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodAtFridge_CookedMeasureType",
                table: "FoodAtFridge",
                column: "CookedMeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAtFridge_PracticalMeasureType",
                table: "FoodAtFridge",
                column: "PracticalMeasureType");

            migrationBuilder.AddForeignKey(
                name: "FK__FoodAtFri__Cooke__151B244E",
                table: "FoodAtFridge",
                column: "CookedMeasureType",
                principalTable: "MeasureType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FoodAtFri__Pract__160F4887",
                table: "FoodAtFridge",
                column: "PracticalMeasureType",
                principalTable: "MeasureType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FoodAtFri__Cooke__151B244E",
                table: "FoodAtFridge");

            migrationBuilder.DropForeignKey(
                name: "FK__FoodAtFri__Pract__160F4887",
                table: "FoodAtFridge");

            migrationBuilder.DropIndex(
                name: "IX_FoodAtFridge_CookedMeasureType",
                table: "FoodAtFridge");

            migrationBuilder.DropIndex(
                name: "IX_FoodAtFridge_PracticalMeasureType",
                table: "FoodAtFridge");

            migrationBuilder.DropColumn(
                name: "CookedMeasureType",
                table: "FoodAtFridge");

            migrationBuilder.DropColumn(
                name: "CookedQuantity",
                table: "FoodAtFridge");

            migrationBuilder.DropColumn(
                name: "PracticalMeasureType",
                table: "FoodAtFridge");

            migrationBuilder.DropColumn(
                name: "PracticalQuantity",
                table: "FoodAtFridge");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "FoodConsumed",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasureType",
                table: "FoodConsumed",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "FoodAtFridge",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "FoodAtFridge",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasureType",
                table: "FoodAtFridge",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
