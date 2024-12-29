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

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FoodTypeNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.FoodType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__food__FoodType__4AB81AF0");
        });

        modelBuilder.Entity<FoodAtFridge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodatfr__3214EC072CCCD628");

            entity.ToTable("FoodAtFridge");

            entity.Property(e => e.Id).ValueGeneratedNever();
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

            entity.Property(e => e.Id).ValueGeneratedNever();
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

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodConsumeds)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatmeas__User__66603565");
        });

        modelBuilder.Entity<FoodMenuMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodatfr__3214EC072CCCD628_copy1");

            entity.ToTable("FoodMenuMeasure");

            entity.Property(e => e.Id).ValueGeneratedNever();
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

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.FoodMenuMeasures)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodatfrid__User__59063A47");
        });

        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodtype__3213E83FCBAE970F");

            entity.ToTable("FoodType");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FoodTypeGroupNavigation).WithMany(p => p.FoodTypes)
                .HasForeignKey(d => d.FoodTypeGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__foodtype__FoodTy__4E88ABD4");
        });

        modelBuilder.Entity<FoodTypeGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__foodtype__3214EC070C9807DF");

            entity.ToTable("FoodTypeGroup");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GroupUnitMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__groupuni__3214EC073F309D1E");

            entity.ToTable("GroupUnitMenu");

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

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UnitMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unitmenu__3214EC0726FCE74C");

            entity.ToTable("UnitMenu");

            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FoodTypeNavigation).WithMany(p => p.UnitMenus)
                .HasForeignKey(d => d.FoodType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__unitmenu__FoodTy__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3214EC07C7E3E507");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WaterMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WaterMea__3214EC07C392C313");

            entity.ToTable("WaterMeasure");

            entity.Property(e => e.Id).ValueGeneratedNever();

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
