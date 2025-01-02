namespace nutriapp.core.Entities;

public partial class MeasureType : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public double ConversionFactor { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<FoodAtFridge> FoodAtFridgeCookedMeasureTypeNavigations { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodAtFridge> FoodAtFridgeMeasureTypeNavigations { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodAtFridge> FoodAtFridgePracticalMeasureTypeNavigations { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumedCookedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodConsumed> FoodConsumedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodConsumed> FoodConsumedPracticalMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureCookedMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<WaterConsumed> WaterConsumed { get; set; } = new List<WaterConsumed>();
    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasurePracticalMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<WaterMeasure> WaterMeasures { get; set; } = new List<WaterMeasure>();

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
