using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodTypeGroup",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
