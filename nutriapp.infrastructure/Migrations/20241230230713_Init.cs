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
                    User = table.Column<int>(type: "int", nullable: false),
                    FoodType = table.Column<int>(type: "int", nullable: false),
                    MaxQuantity = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__unitmenu__3214EC0726FCE74C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UnitMenu__User__06CD04F7",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
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
                    PracticalQuantity = table.Column<double>(type: "float", nullable: true),
                    PracticalMeasureType = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foodatfr__3214EC072CCCD628_copy1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FoodMenuM__Pract__10566F31",
                        column: x => x.PracticalMeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
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
                table: "FoodTypeGroup",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lácteos" },
                    { 2, "Proteínas" },
                    { 3, "Frutas" },
                    { 4, "Vegetales" },
                    { 5, "Carbohidratos" },
                    { 6, "Grasas" }
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

            migrationBuilder.InsertData(
                table: "FoodType",
                columns: new[] { "Id", "FoodTypeGroup", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Lácteos" },
                    { 2, 2, "Proteínas magras" },
                    { 3, 2, "Proteína medianamente grasa" },
                    { 4, 2, "Proteínas altas en grasa" },
                    { 5, 3, "Frutas" },
                    { 6, 4, "Vegetales Tipo A" },
                    { 7, 4, "Vegetales Tipo B" },
                    { 8, 5, "Carbohidratos" },
                    { 9, 6, "Grasas Poli" },
                    { 10, 6, "Grasas mono" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "FoodType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Leche Líquida descremada" },
                    { 2, 1, "Leche en polvo descremada" },
                    { 3, 1, "Kefir" },
                    { 4, 1, "Yogurt griego" },
                    { 5, 2, "Carne vacuna" },
                    { 6, 2, "Lomito desgrasado" },
                    { 7, 2, "Pollo" },
                    { 8, 2, "Pavo" },
                    { 9, 2, "Gallina" },
                    { 10, 2, "Pescado fresco" },
                    { 11, 2, "Cangrejo" },
                    { 12, 2, "Camarones" },
                    { 13, 2, "Sardinas" },
                    { 14, 2, "Queso bajo en grasa" },
                    { 15, 2, "Requesón" },
                    { 16, 2, "Queso Parmesano" },
                    { 17, 2, "Clara de huevo" },
                    { 18, 3, "Carne molida" },
                    { 19, 3, "Cordero" },
                    { 20, 3, "Costilla" },
                    { 21, 3, "Lomo" },
                    { 22, 3, "Queso Mozzarella" },
                    { 23, 3, "Jamón de pavo" },
                    { 24, 3, "Jamón de pollo" },
                    { 25, 3, "Huevo" },
                    { 26, 4, "Jamón de pierna" },
                    { 27, 4, "Jamón de espalda" },
                    { 28, 4, "Mortadela" },
                    { 29, 4, "Tocino" },
                    { 30, 4, "Queso Amarillo" },
                    { 31, 5, "Cambur manzano" },
                    { 32, 5, "Cambur topocho" },
                    { 33, 5, "Cambur guineo" },
                    { 34, 5, "Ciruela fresca" },
                    { 35, 5, "Ciruela pasa" },
                    { 36, 5, "Durazno" },
                    { 37, 5, "Fresas" },
                    { 38, 5, "Guayaba" },
                    { 39, 5, "Guanábana" },
                    { 40, 5, "Limón" },
                    { 41, 5, "Lechosa" },
                    { 42, 5, "Melón" },
                    { 43, 5, "Mandarina" },
                    { 44, 5, "Mango" },
                    { 45, 5, "Mamón" },
                    { 46, 5, "Melocotón" },
                    { 47, 5, "Mora" },
                    { 48, 5, "Naranja" },
                    { 49, 5, "Jugo de Naranja" },
                    { 50, 5, "Patilla" },
                    { 51, 5, "Parchita" },
                    { 52, 5, "Pera" },
                    { 53, 5, "Manzana" },
                    { 54, 5, "Piña" },
                    { 55, 5, "Tamarindo" },
                    { 56, 5, "Uva" },
                    { 57, 5, "Jugo de frutas" },
                    { 58, 6, "Acelga" },
                    { 59, 6, "Ajo porro" },
                    { 60, 6, "Apio españa" },
                    { 61, 6, "Berenjena" },
                    { 62, 6, "Brócoli" },
                    { 63, 6, "Calabacin" },
                    { 64, 6, "Champiñón" },
                    { 65, 6, "Cebollin" },
                    { 66, 6, "Coliflor" },
                    { 67, 6, "Espinaca" },
                    { 68, 6, "Lechuga" },
                    { 69, 6, "Pepino" },
                    { 70, 6, "Perejil" },
                    { 71, 6, "Pimentón" },
                    { 72, 6, "Repollo" },
                    { 73, 6, "Tomate" },
                    { 74, 7, "Auyama" },
                    { 75, 7, "Cebolla" },
                    { 76, 7, "Remolacha" },
                    { 77, 7, "Vainitas" },
                    { 78, 7, "Zanahoria" },
                    { 79, 8, "Arepa" },
                    { 80, 8, "Bollo" },
                    { 81, 8, "Pan de Sándwich" },
                    { 82, 8, "Pan árabe" },
                    { 83, 8, "Casabe" },
                    { 84, 8, "Avena" },
                    { 85, 8, "Harina de trigo" },
                    { 86, 8, "Quinoa" },
                    { 87, 8, "Polenta" },
                    { 88, 8, "Cuscus" },
                    { 89, 8, "Cotufas" },
                    { 90, 8, "Harina de arroz" },
                    { 91, 8, "Harina de avena" },
                    { 92, 8, "Harina de fororo" },
                    { 93, 8, "Pasta cocida" },
                    { 94, 8, "Arroz blanco" },
                    { 95, 8, "Arroz integral cocido" },
                    { 96, 8, "Yuca" },
                    { 97, 8, "Ocumo" },
                    { 98, 8, "Name" },
                    { 99, 8, "Apio" },
                    { 100, 8, "Batata" },
                    { 101, 8, "Plátano" },
                    { 102, 8, "Papa cocida" },
                    { 103, 8, "Panqueca" },
                    { 104, 8, "Granos" },
                    { 105, 8, "Maíz Mazorca" },
                    { 106, 8, "Galletas de soda" },
                    { 107, 8, "Belvita Kraker" },
                    { 108, 9, "Mayonesa" },
                    { 109, 9, "Queso crema" },
                    { 110, 9, "Tahini" },
                    { 111, 10, "Aguacate" },
                    { 112, 10, "Aceite de oliva" },
                    { 113, 10, "Mantequilla de mani" },
                    { 114, 10, "Mantequilla de almendra" },
                    { 115, 10, "Mantequilla de cajú" },
                    { 116, 10, "Almendra" },
                    { 117, 10, "Maní" },
                    { 118, 10, "Pecanas" }
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
                name: "IX_FoodMenuMeasure_PracticalMeasureType",
                table: "FoodMenuMeasure",
                column: "PracticalMeasureType");

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
                name: "IX_UnitMenu_User",
                table: "UnitMenu",
                column: "User");

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
