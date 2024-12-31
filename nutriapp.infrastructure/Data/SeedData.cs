using nutriapp.core.Entities;

namespace nutriapp.infrastructure.Data;

public static class SeedData
{
    public readonly static List<MeasureType> MeasureTypes =
    [
        new() { Id = 1, Name = "Gramo", ConversionFactor = 1, Abbreviation = "gr.", Type = "Masa" },
        new() { Id = 2, Name = "Kilogramo", ConversionFactor = 1000, Abbreviation = "kg.", Type = "Masa" },
        new() { Id = 3, Name = "Litro", ConversionFactor = 1, Abbreviation = "lt.", Type = "Capacidad" },
        new() { Id = 4, Name = "Mililitro", ConversionFactor = 1000, Abbreviation = "ml.", Type = "Capacidad" },
        new() { Id = 5, Name = "Taza", ConversionFactor = 1, Abbreviation = "copa", Type = "Taza" },
        new() { Id = 6, Name = "Unidad", ConversionFactor = 1, Abbreviation = "und.", Type = "Unidad" },
        new() { Id = 7, Name = "Cuchara", ConversionFactor = 1, Abbreviation = "cda.", Type = "Cuchara" },
        new() { Id = 8, Name = "Cucharadita", ConversionFactor = 1, Abbreviation = "cta.", Type = "Cucharadita" },
        new() { Id = 9, Name = "Rebanada", ConversionFactor = 1, Abbreviation = "reb.", Type = "Rebanada" },
        new() { Id = 10, Name = "Puño", ConversionFactor = 1, Abbreviation = "puño", Type = "Puño" },
        new() { Id = 11, Name = "Vaso", ConversionFactor = 1, Abbreviation = "vaso", Type = "Vaso" }
    ];

    public readonly static List<Food> Food = 
    [
        //Lácteos
        new() { Id = 1, Name = "Leche Líquida descremada", FoodType = 1 },
        new() { Id = 2, Name = "Leche en polvo descremada", FoodType = 1 },
        new() { Id = 3, Name = "Kefir", FoodType = 1 },
        new() { Id = 4, Name = "Yogurt griego", FoodType = 1 },

        //Proteínas magras
        new() { Id = 5, Name = "Carne vacuna", FoodType = 2 },
        new() { Id = 6, Name = "Lomito desgrasado", FoodType = 2 },
        new() { Id = 7, Name = "Pollo", FoodType = 2 },
        new() { Id = 8, Name = "Pavo", FoodType = 2 },
        new() { Id = 9, Name = "Gallina", FoodType = 2 },
        new() { Id = 10, Name = "Pescado fresco", FoodType = 2 },
        new() { Id = 11, Name = "Cangrejo", FoodType = 2 },
        new() { Id = 12, Name = "Camarones", FoodType = 2 },
        new() { Id = 13, Name = "Sardinas", FoodType = 2 },
        new() { Id = 14, Name = "Queso bajo en grasa", FoodType = 2 },
        new() { Id = 15, Name = "Requesón", FoodType = 2 },
        new() { Id = 16, Name = "Queso Parmesano", FoodType = 2 },
        new() { Id = 17, Name = "Clara de huevo", FoodType = 2 },

        //Proteína medianamente grasa
        new() { Id = 18, Name = "Carne molida", FoodType = 3 },
        new() { Id = 19, Name = "Cordero", FoodType = 3 },
        new() { Id = 20, Name = "Costilla", FoodType = 3 },
        new() { Id = 21, Name = "Lomo", FoodType = 3 },
        new() { Id = 22, Name = "Queso Mozzarella", FoodType = 3 },
        new() { Id = 23, Name = "Jamón de pavo", FoodType = 3 },
        new() { Id = 24, Name = "Jamón de pollo", FoodType = 3 },
        new() { Id = 25, Name = "Huevo", FoodType = 3 },

        //Proteínas altas en grasa
        new() { Id = 26, Name = "Jamón de pierna", FoodType = 4 },
        new() { Id = 27, Name = "Jamón de espalda", FoodType = 4 },
        new() { Id = 28, Name = "Mortadela", FoodType = 4 },
        new() { Id = 29, Name = "Tocino", FoodType = 4 },
        new() { Id = 30, Name = "Queso Amarillo", FoodType = 4 },

        //Frutas
        new() { Id = 31, Name = "Cambur manzano", FoodType = 5 },
        new() { Id = 32, Name = "Cambur topocho", FoodType = 5 },
        new() { Id = 33, Name = "Cambur guineo", FoodType = 5 },
        new() { Id = 34, Name = "Ciruela fresca", FoodType = 5 },
        new() { Id = 35, Name = "Ciruela pasa", FoodType = 5 },
        new() { Id = 36, Name = "Durazno", FoodType = 5 },
        new() { Id = 37, Name = "Fresas", FoodType = 5 },
        new() { Id = 38, Name = "Guayaba", FoodType = 5 },
        new() { Id = 39, Name = "Guanábana", FoodType = 5 },
        new() { Id = 40, Name = "Limón", FoodType = 5 },
        new() { Id = 41, Name = "Lechosa", FoodType = 5 },
        new() { Id = 42, Name = "Melón", FoodType = 5 },
        new() { Id = 43, Name = "Mandarina", FoodType = 5 },
        new() { Id = 44, Name = "Mango", FoodType = 5 },
        new() { Id = 45, Name = "Mamón", FoodType = 5 },
        new() { Id = 46, Name = "Melocotón", FoodType = 5 },
        new() { Id = 47, Name = "Mora", FoodType = 5 },
        new() { Id = 48, Name = "Naranja", FoodType = 5 },
        new() { Id = 49, Name = "Jugo de Naranja", FoodType = 5 },
        new() { Id = 50, Name = "Patilla", FoodType = 5 },
        new() { Id = 51, Name = "Parchita", FoodType = 5 },
        new() { Id = 52, Name = "Pera", FoodType = 5 },
        new() { Id = 53, Name = "Manzana", FoodType = 5 },
        new() { Id = 54, Name = "Piña", FoodType = 5 },
        new() { Id = 55, Name = "Tamarindo", FoodType = 5 },
        new() { Id = 56, Name = "Uva", FoodType = 5 },
        new() { Id = 57, Name = "Jugo de frutas", FoodType = 5 },

        //Vegetales Tipo A
        new() { Id = 58, Name = "Acelga", FoodType = 6 },
        new() { Id = 59, Name = "Ajo porro", FoodType = 6 },
        new() { Id = 60, Name = "Apio españa", FoodType = 6 },
        new() { Id = 61, Name = "Berenjena", FoodType = 6 },
        new() { Id = 62, Name = "Brócoli", FoodType = 6 },
        new() { Id = 63, Name = "Calabacin", FoodType = 6 },
        new() { Id = 64, Name = "Champiñón", FoodType = 6 },
        new() { Id = 65, Name = "Cebollin", FoodType = 6 },
        new() { Id = 66, Name = "Coliflor", FoodType = 6 },
        new() { Id = 67, Name = "Espinaca", FoodType = 6 },
        new() { Id = 68, Name = "Lechuga", FoodType = 6 },
        new() { Id = 69, Name = "Pepino", FoodType = 6 },
        new() { Id = 70, Name = "Perejil", FoodType = 6 },
        new() { Id = 71, Name = "Pimentón", FoodType = 6 },
        new() { Id = 72, Name = "Repollo", FoodType = 6 },
        new() { Id = 73, Name = "Tomate", FoodType = 6 },

        //Vegetales Tipo B
        new() { Id = 74, Name = "Auyama", FoodType = 7 },
        new() { Id = 75, Name = "Cebolla", FoodType = 7 },
        new() { Id = 76, Name = "Remolacha", FoodType = 7 },
        new() { Id = 77, Name = "Vainitas", FoodType = 7 },
        new() { Id = 78, Name = "Zanahoria", FoodType = 7 },

        //Carbohidratos
        new() { Id = 79, Name = "Arepa", FoodType = 8 },
        new() { Id = 80, Name = "Bollo", FoodType = 8 },
        new() { Id = 81, Name = "Pan de Sándwich", FoodType = 8 },
        new() { Id = 82, Name = "Pan árabe", FoodType = 8 },
        new() { Id = 83, Name = "Casabe", FoodType = 8 },
        new() { Id = 84, Name = "Avena", FoodType = 8 },
        new() { Id = 85, Name = "Harina de trigo", FoodType = 8 },
        new() { Id = 86, Name = "Quinoa", FoodType = 8 },
        new() { Id = 87, Name = "Polenta", FoodType = 8 },
        new() { Id = 88, Name = "Cuscus", FoodType = 8 },
        new() { Id = 89, Name = "Cotufas", FoodType = 8 },
        new() { Id = 90, Name = "Harina de arroz", FoodType = 8 },
        new() { Id = 91, Name = "Harina de avena", FoodType = 8 },
        new() { Id = 92, Name = "Harina de fororo", FoodType = 8 },
        new() { Id = 93, Name = "Pasta cocida", FoodType = 8 },
        new() { Id = 94, Name = "Arroz blanco", FoodType = 8 },
        new() { Id = 95, Name = "Arroz integral cocido", FoodType = 8 },
        new() { Id = 96, Name = "Yuca", FoodType = 8 },
        new() { Id = 97, Name = "Ocumo", FoodType = 8 },
        new() { Id = 98, Name = "Name", FoodType = 8 },
        new() { Id = 99, Name = "Apio", FoodType = 8 },
        new() { Id = 100, Name = "Batata", FoodType = 8 },
        new() { Id = 101, Name = "Plátano", FoodType = 8 },
        new() { Id = 102, Name = "Papa cocida", FoodType = 8 },
        new() { Id = 103, Name = "Panqueca", FoodType = 8 },
        new() { Id = 104, Name = "Granos", FoodType = 8 },
        new() { Id = 105, Name = "Maíz Mazorca", FoodType = 8 },
        new() { Id = 106, Name = "Galletas de soda", FoodType = 8 },
        new() { Id = 107, Name = "Belvita Kraker", FoodType = 8 },

        //Grasas Poli
        new() { Id = 108, Name = "Mayonesa", FoodType = 9 },
        new() { Id = 109, Name = "Queso crema", FoodType = 9 },
        new() { Id = 110, Name = "Tahini", FoodType = 9 },

        //Grasas mono
        new() { Id = 111, Name = "Aguacate", FoodType = 10 },
        new() { Id = 112, Name = "Aceite de oliva", FoodType = 10 },
        new() { Id = 113, Name = "Mantequilla de mani", FoodType = 10 },
        new() { Id = 114, Name = "Mantequilla de almendra", FoodType = 10 },
        new() { Id = 115, Name = "Mantequilla de cajú", FoodType = 10 },
        new() { Id = 116, Name = "Almendra", FoodType = 10 },
        new() { Id = 117, Name = "Maní", FoodType = 10 },
        new() { Id = 118, Name = "Pecanas", FoodType = 10 }
    ];

    public readonly static List<Dictionary<string, object>> MeasuredBy =
    [
        // Lácteos
        new() { ["Food"] = 1, ["MeasureType"] = 4 }, // Leche líquida: Taza 
        new() { ["Food"] = 1, ["MeasureType"] = 5 }, // Leche líquida: Taza 
        new() { ["Food"] = 1, ["MeasureType"] = 11 }, // Leche líquida: Taza 
        new() { ["Food"] = 2, ["MeasureType"] = 7 }, // Leche en polvo: Cuchara 
        new() { ["Food"] = 2, ["MeasureType"] = 1 }, // Leche en polvo: Gramo 
        new() { ["Food"] = 3, ["MeasureType"] = 5 }, // Kefir: Taza 
        new() { ["Food"] = 3, ["MeasureType"] = 4 }, // Kefir: Taza 
        new() { ["Food"] = 4, ["MeasureType"] = 5 }, // Yogurt griego: Taza 
        new() { ["Food"] = 4, ["MeasureType"] = 4 }, // Yogurt griego: Taza 

        // Proteínas magras
        new() { ["Food"] = 5, ["MeasureType"] = 5 }, // Carne vacuna: Taza 
        new() { ["Food"] = 5, ["MeasureType"] = 1 }, // Carne vacuna: Taza 
        new() { ["Food"] = 6, ["MeasureType"] = 5 }, // Lomito desgrasado: Taza 
        new() { ["Food"] = 6, ["MeasureType"] = 1 }, // Lomito desgrasado: Taza 
        new() { ["Food"] = 7, ["MeasureType"] = 5 }, // Pollo: Taza 
        new() { ["Food"] = 7, ["MeasureType"] = 1 }, // Pollo: Taza 
        new() { ["Food"] = 8, ["MeasureType"] = 5 }, // Pavo: Taza 
        new() { ["Food"] = 8, ["MeasureType"] = 1 }, // Pavo: Taza 
        new() { ["Food"] = 9, ["MeasureType"] = 5 }, // Gallina: Taza 
        new() { ["Food"] = 9, ["MeasureType"] = 1 }, // Gallina: Taza 
        new() { ["Food"] = 10, ["MeasureType"] = 5 }, // Pescado fresco: Taza 
        new() { ["Food"] = 10, ["MeasureType"] = 1 }, // Pescado fresco: Taza 
        new() { ["Food"] = 11, ["MeasureType"] = 5 }, // Cangrejo: Taza 
        new() { ["Food"] = 11, ["MeasureType"] = 1 }, // Cangrejo: Taza 
        new() { ["Food"] = 12, ["MeasureType"] = 5 }, // Camarones: Taza 
        new() { ["Food"] = 12, ["MeasureType"] = 1 }, // Camarones: Taza 
        new() { ["Food"] = 13, ["MeasureType"] = 6 }, // Sardinas: Unidad 
        new() { ["Food"] = 13, ["MeasureType"] = 1 }, // Sardinas: Unidad 
        new() { ["Food"] = 14, ["MeasureType"] = 5 }, // Queso bajo en grasa: Taza 
        new() { ["Food"] = 14, ["MeasureType"] = 1 }, // Queso bajo en grasa: Taza 
        new() { ["Food"] = 15, ["MeasureType"] = 5 }, // Requesón: Taza 
        new() { ["Food"] = 15, ["MeasureType"] = 1 }, // Requesón: Taza 
        new() { ["Food"] = 16, ["MeasureType"] = 7 }, // Queso Parmesano: Cuchara 
        new() { ["Food"] = 16, ["MeasureType"] = 1 }, // Queso Parmesano: Cuchara 
        new() { ["Food"] = 17, ["MeasureType"] = 6 }, // Clara de huevo: Unidad 
        new() { ["Food"] = 17, ["MeasureType"] = 1 }, // Clara de huevo: Unidad 

        // Proteína medianamente grasa
        new() { ["Food"] = 18, ["MeasureType"] = 5 }, // Carne molida: Taza
        new() { ["Food"] = 18, ["MeasureType"] = 1 }, // Carne molida: Taza
        new() { ["Food"] = 19, ["MeasureType"] = 5 }, // Cordero: Taza
        new() { ["Food"] = 19, ["MeasureType"] = 1 }, // Cordero: Taza
        new() { ["Food"] = 20, ["MeasureType"] = 5 }, // Costilla: Taza
        new() { ["Food"] = 20, ["MeasureType"] = 1 }, // Costilla: Taza
        new() { ["Food"] = 21, ["MeasureType"] = 5 }, // Lomo: Taza
        new() { ["Food"] = 21, ["MeasureType"] = 1 }, // Lomo: Taza
        new() { ["Food"] = 22, ["MeasureType"] = 5 }, // Queso Mozzarella: Taza
        new() { ["Food"] = 22, ["MeasureType"] = 1 }, // Queso Mozzarella: Taza
        new() { ["Food"] = 23, ["MeasureType"] = 9 }, // Jamón de pavo: Rebanada
        new() { ["Food"] = 23, ["MeasureType"] = 1 }, // Jamón de pavo: Rebanada
        new() { ["Food"] = 24, ["MeasureType"] = 9 }, // Jamón de pollo: Rebanada
        new() { ["Food"] = 24, ["MeasureType"] = 1 }, // Jamón de pollo: Rebanada
        new() { ["Food"] = 25, ["MeasureType"] = 6 }, // Huevo: Unidad
        new() { ["Food"] = 25, ["MeasureType"] = 1 }, // Huevo: Unidad

        // Proteínas altas en grasa
        new() { ["Food"] = 26, ["MeasureType"] = 9 }, // Jamón de pierna: Rebanada
        new() { ["Food"] = 26, ["MeasureType"] = 1 }, // Jamón de pierna: Rebanada
        new() { ["Food"] = 27, ["MeasureType"] = 9 }, // Jamón de espalda: Rebanada
        new() { ["Food"] = 27, ["MeasureType"] = 1 }, // Jamón de espalda: Rebanada
        new() { ["Food"] = 28, ["MeasureType"] = 5 }, // Mortadela: Taza
        new() { ["Food"] = 28, ["MeasureType"] = 1 }, // Mortadela: Taza
        new() { ["Food"] = 29, ["MeasureType"] = 6 }, // Tocino: Unidad
        new() { ["Food"] = 29, ["MeasureType"] = 1 }, // Tocino: Unidad
        new() { ["Food"] = 30, ["MeasureType"] = 9 }, // Queso Amarillo: Rebanada
        new() { ["Food"] = 30, ["MeasureType"] = 1 }, // Queso Amarillo: Rebanada

        // Frutas
        new() { ["Food"] = 31, ["MeasureType"] = 6 }, // Cambur manzano: Unidad
        new() { ["Food"] = 31, ["MeasureType"] = 1 }, // Cambur manzano: Unidad
        new() { ["Food"] = 32, ["MeasureType"] = 6 }, // Cambur topocho: Unidad
        new() { ["Food"] = 32, ["MeasureType"] = 1 }, // Cambur topocho: Unidad
        new() { ["Food"] = 33, ["MeasureType"] = 6 }, // Cambur guineo: Unidad
        new() { ["Food"] = 33, ["MeasureType"] = 1 }, // Cambur guineo: Unidad
        new() { ["Food"] = 34, ["MeasureType"] = 6 }, // Ciruela fresca: Unidad
        new() { ["Food"] = 34, ["MeasureType"] = 1 }, // Ciruela fresca: Unidad
        new() { ["Food"] = 35, ["MeasureType"] = 6 }, // Ciruela pasa: Unidad
        new() { ["Food"] = 35, ["MeasureType"] = 1 }, // Ciruela pasa: Unidad
        new() { ["Food"] = 36, ["MeasureType"] = 6 }, // Durazno: Unidad
        new() { ["Food"] = 36, ["MeasureType"] = 1 }, // Durazno: Unidad
        new() { ["Food"] = 37, ["MeasureType"] = 5 }, // Fresas: Taza
        new() { ["Food"] = 37, ["MeasureType"] = 1 }, // Fresas: Taza
        new() { ["Food"] = 38, ["MeasureType"] = 6 }, // Guayaba: Unidad
        new() { ["Food"] = 38, ["MeasureType"] = 1 }, // Guayaba: Unidad
        new() { ["Food"] = 39, ["MeasureType"] = 5 }, // Guanábana: Taza
        new() { ["Food"] = 39, ["MeasureType"] = 1 }, // Guanábana: Taza
        new() { ["Food"] = 40, ["MeasureType"] = 6 }, // Limón: Unidad
        new() { ["Food"] = 40, ["MeasureType"] = 1 }, // Limón: Unidad
        new() { ["Food"] = 41, ["MeasureType"] = 5 }, // Lechosa: Taza
        new() { ["Food"] = 41, ["MeasureType"] = 1 }, // Lechosa: Taza
        new() { ["Food"] = 42, ["MeasureType"] = 5 }, // Melón: Taza
        new() { ["Food"] = 42, ["MeasureType"] = 1 }, // Melón: Taza
        new() { ["Food"] = 43, ["MeasureType"] = 6 }, // Mandarina: Unidad
        new() { ["Food"] = 43, ["MeasureType"] = 1 }, // Mandarina: Unidad
        new() { ["Food"] = 44, ["MeasureType"] = 6 }, // Mango: Unidad
        new() { ["Food"] = 44, ["MeasureType"] = 1 }, // Mango: Unidad
        new() { ["Food"] = 45, ["MeasureType"] = 5 }, // Mamón: Taza
        new() { ["Food"] = 45, ["MeasureType"] = 1 }, // Mamón: Taza
        new() { ["Food"] = 46, ["MeasureType"] = 6 }, // Melocotón: Unidad
        new() { ["Food"] = 46, ["MeasureType"] = 1 }, // Melocotón: Unidad
        new() { ["Food"] = 47, ["MeasureType"] = 6 }, // Mora: Unidad
        new() { ["Food"] = 47, ["MeasureType"] = 1 }, // Mora: Unidad
        new() { ["Food"] = 48, ["MeasureType"] = 6 }, // Naranja: Unidad
        new() { ["Food"] = 48, ["MeasureType"] = 1 }, // Naranja: Unidad
        new() { ["Food"] = 49, ["MeasureType"] = 11 }, // Jugo de Naranja: Vaso
        new() { ["Food"] = 49, ["MeasureType"] = 4 }, // Jugo de Naranja: Vaso
        new() { ["Food"] = 50, ["MeasureType"] = 5 }, // Patilla: Taza 
        new() { ["Food"] = 50, ["MeasureType"] = 1 }, // Patilla: Taza 
        new() { ["Food"] = 51, ["MeasureType"] = 6 }, // Parchita: Unidad 
        new() { ["Food"] = 51, ["MeasureType"] = 1 }, // Parchita: Unidad 
        new() { ["Food"] = 52, ["MeasureType"] = 6 }, // Pera: Unidad 
        new() { ["Food"] = 52, ["MeasureType"] = 1 }, // Pera: Unidad 
        new() { ["Food"] = 53, ["MeasureType"] = 6 }, // Manzana: Unidad 
        new() { ["Food"] = 53, ["MeasureType"] = 1 }, // Manzana: Unidad 
        new() { ["Food"] = 54, ["MeasureType"] = 9 }, // Piña: Rebanada 
        new() { ["Food"] = 54, ["MeasureType"] = 1 }, // Piña: Rebanada 
        new() { ["Food"] = 55, ["MeasureType"] = 5 }, // Tamarindo: Taza 
        new() { ["Food"] = 55, ["MeasureType"] = 1 }, // Tamarindo: Taza 
        new() { ["Food"] = 56, ["MeasureType"] = 6 }, // Uva: Unidad 
        new() { ["Food"] = 56, ["MeasureType"] = 1 }, // Uva: Unidad 
        new() { ["Food"] = 57, ["MeasureType"] = 11 }, // Jugo de frutas: Vaso 
        new() { ["Food"] = 57, ["MeasureType"] = 4 }, // Jugo de frutas: Vaso 

        // Vegetales Tipo A
        new() { ["Food"] = 58, ["MeasureType"] = 5 }, // Acelga: Taza
        new() { ["Food"] = 58, ["MeasureType"] = 1 }, // Acelga: Taza
        new() { ["Food"] = 59, ["MeasureType"] = 5 }, // Ajo porro: Taza
        new() { ["Food"] = 59, ["MeasureType"] = 1 }, // Ajo porro: Taza
        new() { ["Food"] = 60, ["MeasureType"] = 5 }, // Apio españa: Taza
        new() { ["Food"] = 60, ["MeasureType"] = 1 }, // Apio españa: Taza
        new() { ["Food"] = 61, ["MeasureType"] = 5 }, // Berenjena: Taza
        new() { ["Food"] = 61, ["MeasureType"] = 1 }, // Berenjena: Taza
        new() { ["Food"] = 62, ["MeasureType"] = 5 }, // Brócoli: Taza
        new() { ["Food"] = 62, ["MeasureType"] = 1 }, // Brócoli: Taza
        new() { ["Food"] = 63, ["MeasureType"] = 5 }, // Calabacin: Taza
        new() { ["Food"] = 63, ["MeasureType"] = 1 }, // Calabacin: Taza
        new() { ["Food"] = 64, ["MeasureType"] = 5 }, // Champiñón: Taza
        new() { ["Food"] = 64, ["MeasureType"] = 1 }, // Champiñón: Taza
        new() { ["Food"] = 65, ["MeasureType"] = 5 }, // Cebollin: Taza
        new() { ["Food"] = 65, ["MeasureType"] = 1 }, // Cebollin: Taza
        new() { ["Food"] = 66, ["MeasureType"] = 5 }, // Coliflor: Taza
        new() { ["Food"] = 66, ["MeasureType"] = 1 }, // Coliflor: Taza
        new() { ["Food"] = 67, ["MeasureType"] = 5 }, // Espinaca: Taza
        new() { ["Food"] = 67, ["MeasureType"] = 1 }, // Espinaca: Taza
        new() { ["Food"] = 68, ["MeasureType"] = 5 }, // Lechuga: Taza
        new() { ["Food"] = 68, ["MeasureType"] = 1 }, // Lechuga: Taza
        new() { ["Food"] = 69, ["MeasureType"] = 5 }, // Pepino: Taza
        new() { ["Food"] = 69, ["MeasureType"] = 1 }, // Pepino: Taza
        new() { ["Food"] = 70, ["MeasureType"] = 5 }, // Perejil: Taza
        new() { ["Food"] = 70, ["MeasureType"] = 1 }, // Perejil: Taza
        new() { ["Food"] = 71, ["MeasureType"] = 5 }, // Pimentón: Taza
        new() { ["Food"] = 71, ["MeasureType"] = 1 }, // Pimentón: Taza
        new() { ["Food"] = 72, ["MeasureType"] = 5 }, // Repollo: Taza
        new() { ["Food"] = 72, ["MeasureType"] = 1 }, // Repollo: Taza
        new() { ["Food"] = 73, ["MeasureType"] = 5 }, // Tomate: Taza
        new() { ["Food"] = 73, ["MeasureType"] = 1 }, // Tomate: Taza

        // Vegetales Tipo B
        new() { ["Food"] = 74, ["MeasureType"] = 5 }, // Auyama: Taza
        new() { ["Food"] = 74, ["MeasureType"] = 1 }, // Auyama: Taza
        new() { ["Food"] = 75, ["MeasureType"] = 5 }, // Cebolla: Taza
        new() { ["Food"] = 75, ["MeasureType"] = 1 }, // Cebolla: Taza
        new() { ["Food"] = 76, ["MeasureType"] = 5 }, // Remolacha: Taza
        new() { ["Food"] = 76, ["MeasureType"] = 1 }, // Remolacha: Taza
        new() { ["Food"] = 77, ["MeasureType"] = 5 }, // Vainitas: Taza
        new() { ["Food"] = 77, ["MeasureType"] = 1 }, // Vainitas: Taza
        new() { ["Food"] = 78, ["MeasureType"] = 5 }, // Zanahoria: Taza
        new() { ["Food"] = 78, ["MeasureType"] = 1 }, // Zanahoria: Taza

        // Carbohidratos
        new() { ["Food"] = 79, ["MeasureType"] = 6 }, // Arepa: Unidad
        new() { ["Food"] = 79, ["MeasureType"] = 1 }, // Arepa: Unidad
        new() { ["Food"] = 80, ["MeasureType"] = 6 }, // Bollo: Unidad
        new() { ["Food"] = 80, ["MeasureType"] = 1 }, // Bollo: Unidad
        new() { ["Food"] = 81, ["MeasureType"] = 9 }, // Pan de Sándwich: Rebanada
        new() { ["Food"] = 81, ["MeasureType"] = 1 }, // Pan de Sándwich: Rebanada
        new() { ["Food"] = 82, ["MeasureType"] = 6 }, // Pan árabe: Unidad
        new() { ["Food"] = 82, ["MeasureType"] = 1 }, // Pan árabe: Unidad
        new() { ["Food"] = 84, ["MeasureType"] = 7 }, // Avena: Cuchara
        new() { ["Food"] = 84, ["MeasureType"] = 1 }, // Avena: Cuchara
        new() { ["Food"] = 85, ["MeasureType"] = 7 }, // Harina de trigo: Cuchara
        new() { ["Food"] = 85, ["MeasureType"] = 1 }, // Harina de trigo: Cuchara
        new() { ["Food"] = 86, ["MeasureType"] = 5 }, // Quinoa: Taza
        new() { ["Food"] = 86, ["MeasureType"] = 1 }, // Quinoa: Taza
        new() { ["Food"] = 87, ["MeasureType"] = 5 }, // Polenta: Taza
        new() { ["Food"] = 87, ["MeasureType"] = 1 }, // Polenta: Taza
        new() { ["Food"] = 88, ["MeasureType"] = 5 }, // Cuscus: Taza
        new() { ["Food"] = 88, ["MeasureType"] = 1 }, // Cuscus: Taza
        new() { ["Food"] = 89, ["MeasureType"] = 5 }, // Cotufas: Taza
        new() { ["Food"] = 89, ["MeasureType"] = 1 }, // Cotufas: Taza
        new() { ["Food"] = 90, ["MeasureType"] = 7 }, // Harina de arroz: Cuchara
        new() { ["Food"] = 90, ["MeasureType"] = 1 }, // Harina de arroz: Cuchara
        new() { ["Food"] = 91, ["MeasureType"] = 7 }, // Harina de avena: Cuchara
        new() { ["Food"] = 91, ["MeasureType"] = 1 }, // Harina de avena: Cuchara
        new() { ["Food"] = 92, ["MeasureType"] = 7 }, // Harina de fororo: Cuchara
        new() { ["Food"] = 92, ["MeasureType"] = 1 }, // Harina de fororo: Cuchara
        new() { ["Food"] = 93, ["MeasureType"] = 5 }, // Pasta cocida: Taza
        new() { ["Food"] = 93, ["MeasureType"] = 1 }, // Pasta cocida: Taza
        new() { ["Food"] = 94, ["MeasureType"] = 5 }, // Arroz blanco: Taza
        new() { ["Food"] = 94, ["MeasureType"] = 1 }, // Arroz blanco: Taza
        new() { ["Food"] = 95, ["MeasureType"] = 5 }, // Arroz integral cocido: Taza
        new() { ["Food"] = 95, ["MeasureType"] = 1 }, // Arroz integral cocido: Taza
        new() { ["Food"] = 96, ["MeasureType"] = 5 }, // Yuca: Taza
        new() { ["Food"] = 96, ["MeasureType"] = 1 }, // Yuca: Taza
        new() { ["Food"] = 97, ["MeasureType"] = 5 }, // Ocumo: Taza
        new() { ["Food"] = 97, ["MeasureType"] = 1 }, // Ocumo: Taza
        new() { ["Food"] = 98, ["MeasureType"] = 5 }, // Name: Taza
        new() { ["Food"] = 98, ["MeasureType"] = 1 }, // Name: Taza
        new() { ["Food"] = 99, ["MeasureType"] = 5 }, // Apio: Taza
        new() { ["Food"] = 99, ["MeasureType"] = 1 }, // Apio: Taza
        new() { ["Food"] = 100, ["MeasureType"] = 5 }, // Batata: Taza
        new() { ["Food"] = 100, ["MeasureType"] = 1 }, // Batata: Taza
        new() { ["Food"] = 101, ["MeasureType"] = 5 }, // Plátano: Taza
        new() { ["Food"] = 101, ["MeasureType"] = 1 }, // Plátano: Taza
        new() { ["Food"] = 102, ["MeasureType"] = 6 }, // Papa cocida: Unidad
        new() { ["Food"] = 102, ["MeasureType"] = 1 }, // Papa cocida: Unidad
        new() { ["Food"] = 103, ["MeasureType"] = 6 }, // Panqueca: Unidad
        new() { ["Food"] = 103, ["MeasureType"] = 1 }, // Panqueca: Unidad
        new() { ["Food"] = 104, ["MeasureType"] = 5 }, // Granos: Taza
        new() { ["Food"] = 104, ["MeasureType"] = 1 }, // Granos: Taza
        new() { ["Food"] = 105, ["MeasureType"] = 6 }, // Maíz Mazorca: Unidad
        new() { ["Food"] = 105, ["MeasureType"] = 1 }, // Maíz Mazorca: Unidad
        new() { ["Food"] = 106, ["MeasureType"] = 6 }, // Galleta soda: Unidad
        new() { ["Food"] = 106, ["MeasureType"] = 1 }, // Galleta soda: Unidad
        new() { ["Food"] = 107, ["MeasureType"] = 6 }, // Belvita Kraker: Unidad
        new() { ["Food"] = 107, ["MeasureType"] = 1 }, // Belvita Kraker: Unidad

        //Grasas Poli
        new() { ["Food"] = 108, ["MeasureType"] = 7 }, // Mayonesa: Unidad
        new() { ["Food"] = 108, ["MeasureType"] = 1 }, // Mayonesa: Unidad
        new() { ["Food"] = 109, ["MeasureType"] = 7 }, // Queso crema: Unidad
        new() { ["Food"] = 109, ["MeasureType"] = 1 }, // Queso crema: Unidad
        new() { ["Food"] = 110, ["MeasureType"] = 8 }, // Tahini: Unidad
        new() { ["Food"] = 110, ["MeasureType"] = 1 }, // Tahini: Unidad

        //Grasas mono
        new() { ["Food"] = 111, ["MeasureType"] = 6 }, // Aguacate: Unidad
        new() { ["Food"] = 111, ["MeasureType"] = 1 }, // Aguacate: Unidad
        new() { ["Food"] = 112, ["MeasureType"] = 6 }, // Aceite de oliva: Unidad
        new() { ["Food"] = 112, ["MeasureType"] = 4 }, // Aceite de oliva: Unidad
        new() { ["Food"] = 113, ["MeasureType"] = 8 }, // Mantequilla de mani: Unidad
        new() { ["Food"] = 113, ["MeasureType"] = 1 }, // Mantequilla de mani: Unidad
        new() { ["Food"] = 114, ["MeasureType"] = 8 }, // Mantequilla de almendra: Unidad
        new() { ["Food"] = 114, ["MeasureType"] = 1 }, // Mantequilla de almendra: Unidad
        new() { ["Food"] = 115, ["MeasureType"] = 8 }, // Mantequilla de cajú: Unidad
        new() { ["Food"] = 115, ["MeasureType"] = 1 }, // Mantequilla de cajú: Unidad
        new() { ["Food"] = 116, ["MeasureType"] = 10 }, // Almendra: Unidad
        new() { ["Food"] = 116, ["MeasureType"] = 1 }, // Almendra: Unidad
        new() { ["Food"] = 117, ["MeasureType"] = 10 }, // Maní: Unidad
        new() { ["Food"] = 117, ["MeasureType"] = 1 }, // Maní: Unidad
        new() { ["Food"] = 118, ["MeasureType"] = 10 }, // Pecanas: Unidad
        new() { ["Food"] = 118, ["MeasureType"] = 1 }, // Pecanas: Unidad
    ];

    public readonly static List<FoodType> FoodType =
    [
        new FoodType { Id = 1, Name = "Lácteos", FoodTypeGroup = 1 },
        new FoodType { Id = 2, Name = "Proteínas magras", FoodTypeGroup = 2 },
        new FoodType { Id = 3, Name = "Proteína medianamente grasa", FoodTypeGroup = 2 },
        new FoodType { Id = 4, Name = "Proteínas altas en grasa", FoodTypeGroup = 2 },
        new FoodType { Id = 5, Name = "Frutas", FoodTypeGroup = 3 },
        new FoodType { Id = 6, Name = "Vegetales Tipo A", FoodTypeGroup = 4 },
        new FoodType { Id = 7, Name = "Vegetales Tipo B", FoodTypeGroup = 4 },
        new FoodType { Id = 8, Name = "Carbohidratos", FoodTypeGroup = 5 },
        new FoodType { Id = 9, Name = "Grasas Poli", FoodTypeGroup = 6 },
        new FoodType { Id = 10, Name = "Grasas mono", FoodTypeGroup = 6 }
    ];

    public readonly static List<FoodTypeGroup> FoodTypeGroup =
    [
        new FoodTypeGroup { Id = 1, Name = "Lácteos" },
        new FoodTypeGroup { Id = 2, Name = "Proteínas" },
        new FoodTypeGroup { Id = 3, Name = "Frutas" },
        new FoodTypeGroup { Id = 4, Name = "Vegetales" },
        new FoodTypeGroup { Id = 5, Name = "Carbohidratos" },
        new FoodTypeGroup { Id = 6, Name = "Grasas" }
    ];
}