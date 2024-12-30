using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodtype__3214EC070C9807DF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    ConversionFactor = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__measuret__3214EC07D870CDE6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValueSql: "(getdate())"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    Lastname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: ""),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__3214EC07C7E3E507", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTypeGroup = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodtype__3213E83FCBAE970F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__foodtype__FoodTy__4E88ABD4",
                        column: x => x.FoodTypeGroup,
                        principalTable: "FoodTypeGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mealtype__3213E83F0ABA1F94", x => x.Id);
                    table.ForeignKey(
                        name: "FK__mealtype__User__4BAC3F29",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WaterConsumed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WaterCon__3214EC07E8C2D1E2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__WaterCons__Measu__74AE54BC",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__WaterConsu__User__75A278F5",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WaterMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WaterMea__3214EC07C392C313", x => x.Id);
                    table.ForeignKey(
                        name: "FK__WaterMeas__Measu__6E01572D",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__WaterMeasu__User__6D0D32F4",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__food__3214EC0783E939C4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__food__FoodType__4AB81AF0",
                        column: x => x.FoodType,
                        principalTable: "FoodType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodType = table.Column<int>(type: "int", nullable: false),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__unitmenu__3214EC0726FCE74C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__unitmenu__FoodTy__45F365D3",
                        column: x => x.FoodType,
                        principalTable: "FoodType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupUnitMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    FoodTypeGroup = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__groupuni__3214EC073F309D1E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__groupunit__FoodT__5629CD9C",
                        column: x => x.FoodTypeGroup,
                        principalTable: "FoodTypeGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__groupunit__MealT__5535A963",
                        column: x => x.MealType,
                        principalTable: "MealType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodAtFridge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodatfr__3214EC072CCCD628", x => x.Id);
                    table.ForeignKey(
                        name: "FK__foodatfri__Measu__534D60F1",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatfrid__Food__5535A963",
                        column: x => x.Food,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatfrid__User__5441852A",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodConsumed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    CookedQuantity = table.Column<double>(type: "float", nullable: true),
                    CookedMeasureType = table.Column<int>(type: "int", nullable: true),
                    Cups = table.Column<double>(type: "float", nullable: true),
                    Units = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodatfr__3214EC072CCCD628_copy1_copy1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__foodatmea__Cooke__68487DD7",
                        column: x => x.CookedMeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatmea__Measu__656C112C",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatmeas__Food__6754599E",
                        column: x => x.Food,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatmeas__User__66603565",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodMenuMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    CookedQuantity = table.Column<double>(type: "float", nullable: true),
                    CookedMeasureType = table.Column<int>(type: "int", nullable: true),
                    Cups = table.Column<double>(type: "float", nullable: true),
                    Units = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodatfr__3214EC072CCCD628_copy1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__foodatfri__Measu__5812160E",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatfrid__Food__59FA5E80",
                        column: x => x.Food,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatfrid__User__59063A47",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__foodatmea__Cooke__5DCAEF64",
                        column: x => x.CookedMeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodType",
                table: "Food",
                column: "FoodType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAtFridge_Food",
                table: "FoodAtFridge",
                column: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAtFridge_MeasureType",
                table: "FoodAtFridge",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAtFridge_User",
                table: "FoodAtFridge",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumed_CookedMeasureType",
                table: "FoodConsumed",
                column: "CookedMeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumed_Food",
                table: "FoodConsumed",
                column: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumed_MeasureType",
                table: "FoodConsumed",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConsumed_User",
                table: "FoodConsumed",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMeasure_CookedMeasureType",
                table: "FoodMenuMeasure",
                column: "CookedMeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMeasure_Food",
                table: "FoodMenuMeasure",
                column: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMeasure_MeasureType",
                table: "FoodMenuMeasure",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMeasure_User",
                table: "FoodMenuMeasure",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_FoodType_FoodTypeGroup",
                table: "FoodType",
                column: "FoodTypeGroup");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUnitMenu_FoodTypeGroup",
                table: "GroupUnitMenu",
                column: "FoodTypeGroup");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUnitMenu_MealType",
                table: "GroupUnitMenu",
                column: "MealType");

            migrationBuilder.CreateIndex(
                name: "IX_MealType_User",
                table: "MealType",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMenu_FoodType",
                table: "UnitMenu",
                column: "FoodType");

            migrationBuilder.CreateIndex(
                name: "IX_WaterConsumed_MeasureType",
                table: "WaterConsumed",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_WaterConsumed_User",
                table: "WaterConsumed",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeasure_MeasureType",
                table: "WaterMeasure",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeasure_User",
                table: "WaterMeasure",
                column: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodAtFridge");

            migrationBuilder.DropTable(
                name: "FoodConsumed");

            migrationBuilder.DropTable(
                name: "FoodMenuMeasure");

            migrationBuilder.DropTable(
                name: "GroupUnitMenu");

            migrationBuilder.DropTable(
                name: "UnitMenu");

            migrationBuilder.DropTable(
                name: "WaterConsumed");

            migrationBuilder.DropTable(
                name: "WaterMeasure");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "MealType");

            migrationBuilder.DropTable(
                name: "MeasureType");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "FoodTypeGroup");
        }
    }
}
