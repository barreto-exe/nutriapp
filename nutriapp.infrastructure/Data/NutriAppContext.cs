using Microsoft.EntityFrameworkCore;
using nutriapp.core.Entities;

namespace nutriapp.infrastructure.Data;

public partial class NutriAppContext : DbContext
{
    public NutriAppContext()
    {
    }

    public NutriAppContext(DbContextOptions<NutriAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodAtFridge> FoodAtFridges { get; set; }

    public virtual DbSet<FoodConsumed> FoodConsumeds { get; set; }

    public virtual DbSet<FoodMenuMeasure> FoodMenuMeasures { get; set; }

    public virtual DbSet<FoodType> FoodTypes { get; set; }

    public virtual DbSet<FoodTypeGroup> FoodTypeGroups { get; set; }

    public virtual DbSet<GroupUnitMenu> GroupUnitMenus { get; set; }

    public virtual DbSet<MealType> MealTypes { get; set; }

    public virtual DbSet<MeasureType> MeasureTypes { get; set; }

    public virtual DbSet<UnitMenu> UnitMenus { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<WaterConsumed> WaterConsumed { get; set; }
    public virtual DbSet<WaterMeasure> WaterMeasures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        //var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        var connUrl = "Data Source=localhost;Initial Catalog=nutriapp;Trusted_Connection=True;TrustServerCertificate=True;";

        if (!string.IsNullOrWhiteSpace(connUrl))
        {
            optionsBuilder.UseSqlServer(connUrl);
        }
    }
    private bool IsRunningInDesignTime()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .Any(assembly => assembly.FullName.StartsWith("EntityFrameworkCore.Design", StringComparison.OrdinalIgnoreCase));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food__3214EC0783E939C4");

            entity.ToTable("Food");

            entity.HasIndex(e => e.FoodType, "IX_Food_FoodType");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FoodTypeNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.FoodType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__food__FoodType__4AB81AF0");

            entity.HasData(
                //Lácteos
                new Food { Id = 1, Name = "Leche Líquida descremada", FoodType = 1 },
                new Food { Id = 2, Name = "Leche en polvo descremada", FoodType = 1 },
                new Food { Id = 3, Name = "Kefir", FoodType = 1 },
                new Food { Id = 4, Name = "Yogurt griego", FoodType = 1 },

                //Proteínas magras
                new Food { Id = 5, Name = "Carne vacuna", FoodType = 2 },
                new Food { Id = 6, Name = "Lomito desgrasado", FoodType = 2 },
                new Food { Id = 7, Name = "Pollo", FoodType = 2 },
                new Food { Id = 8, Name = "Pavo", FoodType = 2 },
                new Food { Id = 9, Name = "Gallina", FoodType = 2 },
                new Food { Id = 10, Name = "Pescado fresco", FoodType = 2 },
                new Food { Id = 11, Name = "Cangrejo", FoodType = 2 },
                new Food { Id = 12, Name = "Camarones", FoodType = 2 },
                new Food { Id = 13, Name = "Sardinas", FoodType = 2 },
                new Food { Id = 14, Name = "Queso bajo en grasa", FoodType = 2 },
                new Food { Id = 15, Name = "Requesón", FoodType = 2 },
                new Food { Id = 16, Name = "Queso Parmesano", FoodType = 2 },
                new Food { Id = 17, Name = "Clara de huevo", FoodType = 2 },

                //Proteína medianamente grasa
                new Food { Id = 18, Name = "Carne molida", FoodType = 3 },
                new Food { Id = 19, Name = "Cordero", FoodType = 3 },
                new Food { Id = 20, Name = "Costilla", FoodType = 3 },
                new Food { Id = 21, Name = "Lomo", FoodType = 3 },
                new Food { Id = 22, Name = "Queso Mozzarella", FoodType = 3 },
                new Food { Id = 23, Name = "Jamón de pavo", FoodType = 3 },
                new Food { Id = 24, Name = "Jamón de pollo", FoodType = 3 },
                new Food { Id = 25, Name = "Huevo", FoodType = 3 },

                //Proteínas altas en grasa
                new Food { Id = 26, Name = "Jamón de pierna", FoodType = 4 },
                new Food { Id = 27, Name = "Jamón de espalda", FoodType = 4 },
                new Food { Id = 28, Name = "Mortadela", FoodType = 4 },
                new Food { Id = 29, Name = "Tocino", FoodType = 4 },
                new Food { Id = 30, Name = "Queso Amarillo", FoodType = 4 },

                //Frutas
                new Food { Id = 31, Name = "Cambur manzano", FoodType = 5 },
                new Food { Id = 32, Name = "Cambur topocho", FoodType = 5 },
                new Food { Id = 33, Name = "Cambur guineo", FoodType = 5 },
                new Food { Id = 34, Name = "Ciruela fresca", FoodType = 5 },
                new Food { Id = 35, Name = "Ciruela pasa", FoodType = 5 },
                new Food { Id = 36, Name = "Durazno", FoodType = 5 },
                new Food { Id = 37, Name = "Fresas", FoodType = 5 },
                new Food { Id = 38, Name = "Guayaba", FoodType = 5 },
                new Food { Id = 39, Name = "Guanábana", FoodType = 5 },
                new Food { Id = 40, Name = "Limón", FoodType = 5 },
                new Food { Id = 41, Name = "Lechosa", FoodType = 5 },
                new Food { Id = 42, Name = "Melón", FoodType = 5 },
                new Food { Id = 43, Name = "Mandarina", FoodType = 5 },
                new Food { Id = 44, Name = "Mango", FoodType = 5 },
                new Food { Id = 45, Name = "Mamón", FoodType = 5 },
                new Food { Id = 46, Name = "Melocotón", FoodType = 5 },
                new Food { Id = 47, Name = "Mora", FoodType = 5 },
                new Food { Id = 48, Name = "Naranja", FoodType = 5 },
                new Food { Id = 49, Name = "Jugo de Naranja", FoodType = 5 },
                new Food { Id = 50, Name = "Patilla", FoodType = 5 },
                new Food { Id = 51, Name = "Parchita", FoodType = 5 },
                new Food { Id = 52, Name = "Pera", FoodType = 5 },
                new Food { Id = 53, Name = "Manzana", FoodType = 5 },
                new Food { Id = 54, Name = "Piña", FoodType = 5 },
                new Food { Id = 55, Name = "Tamarindo", FoodType = 5 },
                new Food { Id = 56, Name = "Uva", FoodType = 5 },
                new Food { Id = 57, Name = "Jugo de frutas", FoodType = 5 },

                //Vegetales Tipo A
                new Food { Id = 58, Name = "Acelga", FoodType = 6 },
                new Food { Id = 59, Name = "Ajo porro", FoodType = 6 },
                new Food { Id = 60, Name = "Apio españa", FoodType = 6 },
                new Food { Id = 61, Name = "Berenjena", FoodType = 6 },
                new Food { Id = 62, Name = "Brócoli", FoodType = 6 },
                new Food { Id = 63, Name = "Calabacin", FoodType = 6 },
                new Food { Id = 64, Name = "Champiñón", FoodType = 6 },
                new Food { Id = 65, Name = "Cebollin", FoodType = 6 },
                new Food { Id = 66, Name = "Coliflor", FoodType = 6 },
                new Food { Id = 67, Name = "Espinaca", FoodType = 6 },
                new Food { Id = 68, Name = "Lechuga", FoodType = 6 },
                new Food { Id = 69, Name = "Pepino", FoodType = 6 },
                new Food { Id = 70, Name = "Perejil", FoodType = 6 },
                new Food { Id = 71, Name = "Pimentón", FoodType = 6 },
                new Food { Id = 72, Name = "Repollo", FoodType = 6 },
                new Food { Id = 73, Name = "Tomate", FoodType = 6 },

                //Vegetales Tipo B
                new Food { Id = 74, Name = "Auyama", FoodType = 7 },
                new Food { Id = 75, Name = "Cebolla", FoodType = 7 },
                new Food { Id = 76, Name = "Remolacha", FoodType = 7 },
                new Food { Id = 77, Name = "Vainitas", FoodType = 7 },
                new Food { Id = 78, Name = "Zanahoria", FoodType = 7 },

                //Carbohidratos
                new Food { Id = 79, Name = "Arepa", FoodType = 8 },
                new Food { Id = 80, Name = "Bollo", FoodType = 8 },
                new Food { Id = 81, Name = "Pan de Sándwich", FoodType = 8 },
                new Food { Id = 82, Name = "Pan árabe", FoodType = 8 },
                new Food { Id = 83, Name = "Casabe", FoodType = 8 },
                new Food { Id = 84, Name = "Avena", FoodType = 8 },
                new Food { Id = 85, Name = "Harina de trigo", FoodType = 8 },
                new Food { Id = 86, Name = "Quinoa", FoodType = 8 },
                new Food { Id = 87, Name = "Polenta", FoodType = 8 },
                new Food { Id = 88, Name = "Cuscus", FoodType = 8 },
                new Food { Id = 89, Name = "Cotufas", FoodType = 8 },
                new Food { Id = 90, Name = "Harina de arroz", FoodType = 8 },
                new Food { Id = 91, Name = "Harina de avena", FoodType = 8 },
                new Food { Id = 92, Name = "Harina de fororo", FoodType = 8 },
                new Food { Id = 93, Name = "Pasta cocida", FoodType = 8 },
                new Food { Id = 94, Name = "Arroz blanco", FoodType = 8 },
                new Food { Id = 95, Name = "Arroz integral cocido", FoodType = 8 },
                new Food { Id = 96, Name = "Yuca", FoodType = 8 },
                new Food { Id = 97, Name = "Ocumo", FoodType = 8 },
                new Food { Id = 98, Name = "Name", FoodType = 8 },
                new Food { Id = 99, Name = "Apio", FoodType = 8 },
                new Food { Id = 100, Name = "Batata", FoodType = 8 },
                new Food { Id = 101, Name = "Plátano", FoodType = 8 },
                new Food { Id = 102, Name = "Papa cocida", FoodType = 8 },
                new Food { Id = 103, Name = "Panqueca", FoodType = 8 },
                new Food { Id = 104, Name = "Granos", FoodType = 8 },
                new Food { Id = 105, Name = "Maíz Mazorca", FoodType = 8 },
                new Food { Id = 106, Name = "Galletas de soda", FoodType = 8 },
                new Food { Id = 107, Name = "Belvita Kraker", FoodType = 8 },

                //Grasas Poli
                new Food { Id = 108, Name = "Mayonesa", FoodType = 9 },
                new Food { Id = 109, Name = "Queso crema", FoodType = 9 },
                new Food { Id = 110, Name = "Tahini", FoodType = 9 },

                //Grasas mono
                new Food { Id = 111, Name = "Aguacate", FoodType = 10 },
                new Food { Id = 112, Name = "Aceite de oliva", FoodType = 10 },
                new Food { Id = 113, Name = "Mantequilla de mani", FoodType = 10 },
                new Food { Id = 114, Name = "Mantequilla de almendra", FoodType = 10 },
                new Food { Id = 115, Name = "Mantequilla de cajú", FoodType = 10 },
                new Food { Id = 116, Name = "Almendra", FoodType = 10 },
                new Food { Id = 117, Name = "Maní", FoodType = 10 },
                new Food { Id = 118, Name = "Pecanas", FoodType = 10 }
            );
        });

        modelBuilder.Entity<FoodAtFridge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodatfr__3214EC072CCCD628");

            entity.ToTable("FoodAtFridge");

            entity.HasIndex(e => e.Food, "IX_FoodAtFridge_Food");

            entity.HasIndex(e => e.MeasureType, "IX_FoodAtFridge_MeasureType");

            entity.HasIndex(e => e.User, "IX_FoodAtFridge_User");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FoodNavigation).WithMany(p => p.FoodAtFridges)
                .HasForeignKey(d => d.Food)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfrid__Food__5535A963");

            entity.HasOne(d => d.MeasureTypeNavigation).WithMany(p => p.FoodAtFridges)
                .HasForeignKey(d => d.MeasureType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfri__Measu__534D60F1");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodAtFridges)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfrid__User__5441852A");
        });

        modelBuilder.Entity<FoodConsumed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodatfr__3214EC072CCCD628_copy1_copy1");

            entity.ToTable("FoodConsumed");

            entity.HasIndex(e => e.CookedMeasureType, "IX_FoodConsumed_CookedMeasureType");

            entity.HasIndex(e => e.Food, "IX_FoodConsumed_Food");

            entity.HasIndex(e => e.MeasureType, "IX_FoodConsumed_MeasureType");

            entity.HasIndex(e => e.User, "IX_FoodConsumed_User");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CookedMeasureTypeNavigation).WithMany(p => p.FoodConsumedCookedMeasureTypeNavigations)
                .HasForeignKey(d => d.CookedMeasureType)
                .HasConstraintName("FK__foodatmea__Cooke__68487DD7");

            entity.HasOne(d => d.FoodNavigation).WithMany(p => p.FoodConsumeds)
                .HasForeignKey(d => d.Food)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatmeas__Food__6754599E");

            entity.HasOne(d => d.MeasureTypeNavigation).WithMany(p => p.FoodConsumedMeasureTypeNavigations)
                .HasForeignKey(d => d.MeasureType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatmea__Measu__656C112C");

            entity.HasOne(d => d.PracticalMeasureTypeNavigation).WithMany(p => p.FoodConsumedPracticalMeasureTypeNavigations)
                .HasForeignKey(d => d.PracticalMeasureType)
                .HasConstraintName("FK__FoodConsu__Pract__04E4BC85");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodConsumeds)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatmeas__User__66603565");
        });

        modelBuilder.Entity<FoodMenuMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodatfr__3214EC072CCCD628_copy1");

            entity.ToTable("FoodMenuMeasure");

            entity.HasIndex(e => e.CookedMeasureType, "IX_FoodMenuMeasure_CookedMeasureType");

            entity.HasIndex(e => e.Food, "IX_FoodMenuMeasure_Food");

            entity.HasIndex(e => e.MeasureType, "IX_FoodMenuMeasure_MeasureType");

            entity.HasIndex(e => e.PracticalMeasureType, "IX_FoodMenuMeasure_PracticalMeasureType");

            entity.HasIndex(e => e.User, "IX_FoodMenuMeasure_User");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CookedMeasureTypeNavigation).WithMany(p => p.FoodMenuMeasureCookedMeasureTypeNavigations)
                .HasForeignKey(d => d.CookedMeasureType)
                .HasConstraintName("FK__foodatmea__Cooke__5DCAEF64");

            entity.HasOne(d => d.FoodNavigation).WithMany(p => p.FoodMenuMeasures)
                .HasForeignKey(d => d.Food)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfrid__Food__59FA5E80");

            entity.HasOne(d => d.MeasureTypeNavigation).WithMany(p => p.FoodMenuMeasureMeasureTypeNavigations)
                .HasForeignKey(d => d.MeasureType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfri__Measu__5812160E");

            entity.HasOne(d => d.PracticalMeasureTypeNavigation).WithMany(p => p.FoodMenuMeasurePracticalMeasureTypeNavigations)
                .HasForeignKey(d => d.PracticalMeasureType)
                .HasConstraintName("FK__FoodMenuM__Pract__10566F31");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodMenuMeasures)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfrid__User__59063A47");
        });

        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodtype__3213E83FCBAE970F");

            entity.ToTable("FoodType");

            entity.HasIndex(e => e.FoodTypeGroup, "IX_FoodType_FoodTypeGroup");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FoodTypeGroupNavigation).WithMany(p => p.FoodTypes)
                .HasForeignKey(d => d.FoodTypeGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodtype__FoodTy__4E88ABD4");

            entity.HasData(
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
            );
        });

        modelBuilder.Entity<FoodTypeGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodtype__3214EC070C9807DF");

            entity.ToTable("FoodTypeGroup");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(
                new FoodTypeGroup { Id = 1, Name = "Lácteos" },
                new FoodTypeGroup { Id = 2, Name = "Proteínas" },
                new FoodTypeGroup { Id = 3, Name = "Frutas" },
                new FoodTypeGroup { Id = 4, Name = "Vegetales" },
                new FoodTypeGroup { Id = 5, Name = "Carbohidratos" },
                new FoodTypeGroup { Id = 6, Name = "Grasas" }
            );
        });

        modelBuilder.Entity<GroupUnitMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groupuni__3214EC073F309D1E");

            entity.ToTable("GroupUnitMenu");

            entity.HasIndex(e => e.FoodTypeGroup, "IX_GroupUnitMenu_FoodTypeGroup");

            entity.HasIndex(e => e.MealType, "IX_GroupUnitMenu_MealType");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FoodTypeGroupNavigation).WithMany(p => p.GroupUnitMenus)
                .HasForeignKey(d => d.FoodTypeGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__groupunit__FoodT__5629CD9C");

            entity.HasOne(d => d.MealTypeNavigation).WithMany(p => p.GroupUnitMenus)
                .HasForeignKey(d => d.MealType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__groupunit__MealT__5535A963");
        });

        modelBuilder.Entity<MealType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mealtype__3213E83F0ABA1F94");

            entity.ToTable("MealType");

            entity.HasIndex(e => e.User, "IX_MealType_User");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.MealTypes)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__mealtype__User__4BAC3F29");
        });

        modelBuilder.Entity<MeasureType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__measuret__3214EC07D870CDE6");

            entity.ToTable("MeasureType");

            entity.Property(e => e.Abbreviation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");

            entity.HasData(
                new MeasureType { Id = 1, Name = "Gramo", ConversionFactor = 1, Abbreviation = "gr.", Type = "Masa" },
                new MeasureType { Id = 2, Name = "Kilogramo", ConversionFactor = 1000, Abbreviation = "kg.", Type = "Masa" },
                new MeasureType { Id = 3, Name = "Litro", ConversionFactor = 1, Abbreviation = "lt.", Type = "Capacidad" },
                new MeasureType { Id = 4, Name = "Mililitro", ConversionFactor = 1000, Abbreviation = "ml.", Type = "Capacidad" },
                new MeasureType { Id = 5, Name = "Taza", ConversionFactor = 1, Abbreviation = "copa", Type = "Taza" },
                new MeasureType { Id = 6, Name = "Unidad", ConversionFactor = 1, Abbreviation = "und.", Type = "Unidad" },
                new MeasureType { Id = 7, Name = "Cuchara", ConversionFactor = 1, Abbreviation = "cda.", Type = "Cuchara" },
                new MeasureType { Id = 8, Name = "Cucharadita", ConversionFactor = 1, Abbreviation = "cta.", Type = "Cucharadita" },
                new MeasureType { Id = 9, Name = "Rebanada", ConversionFactor = 1, Abbreviation = "reb.", Type = "Rebanada" },
                new MeasureType { Id = 10, Name = "Puño", ConversionFactor = 1, Abbreviation = "puño", Type = "Puño" },
                new MeasureType { Id = 11, Name = "Vaso", ConversionFactor = 1, Abbreviation = "vaso", Type = "Vaso" }
            );
        });

        modelBuilder.Entity<UnitMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unitmenu__3214EC0726FCE74C");

            entity.ToTable("UnitMenu");

            entity.HasIndex(e => e.FoodType, "IX_UnitMenu_FoodType");

            entity.HasIndex(e => e.User, "IX_UnitMenu_User");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FoodTypeNavigation).WithMany(p => p.UnitMenus)
                .HasForeignKey(d => d.FoodType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__unitmenu__FoodTy__45F365D3");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.UnitMenus)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UnitMenu__User__06CD04F7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3214EC07C7E3E507");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<WaterConsumed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WaterCon__3214EC07E8C2D1E2");

            entity.ToTable("WaterConsumed");

            entity.HasIndex(e => e.MeasureType, "IX_WaterConsumed_MeasureType");

            entity.HasIndex(e => e.User, "IX_WaterConsumed_User");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MeasureTypeNavigation).WithMany(p => p.WaterConsumed)
                .HasForeignKey(d => d.MeasureType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterCons__Measu__74AE54BC");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.WaterConsumed)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterConsu__User__75A278F5");
        });

        modelBuilder.Entity<WaterMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WaterMea__3214EC07C392C313");

            entity.ToTable("WaterMeasure");

            entity.HasIndex(e => e.MeasureType, "IX_WaterMeasure_MeasureType");

            entity.HasIndex(e => e.User, "IX_WaterMeasure_User");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MeasureTypeNavigation).WithMany(p => p.WaterMeasures)
                .HasForeignKey(d => d.MeasureType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterMeas__Measu__6E01572D");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.WaterMeasures)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterMeasu__User__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
