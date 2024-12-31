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

            entity.HasData(SeedData.Food);

            entity.HasMany(d => d.MeasureTypes).WithMany(p => p.Foods)
                .UsingEntity<Dictionary<string, object>>(
                    "MeasuredBy",
                    r => r.HasOne<MeasureType>().WithMany()
                        .HasForeignKey("MeasureType")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MeasuredB__Measu__08B54D69"),
                    l => l.HasOne<Food>().WithMany()
                        .HasForeignKey("Food")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MeasuredBy__Food__07C12930"),
                    j =>
                    {
                        j.HasKey("Food", "MeasureType").HasName("PK__Measured__92FAF591EA351E7B");
                        j.ToTable("MeasuredBy");
                        j.HasData(SeedData.MeasuredBy);
                    });
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

            entity.HasIndex(e => e.PracticalMeasureType, "IX_FoodConsumed_PracticalMeasureType");

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

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodConsumed)
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

            entity.HasData(SeedData.FoodType);
        });

        modelBuilder.Entity<FoodTypeGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodtype__3214EC070C9807DF");

            entity.ToTable("FoodTypeGroup");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasData(SeedData.FoodTypeGroup);
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

            entity.HasData(SeedData.MeasureTypes);
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
