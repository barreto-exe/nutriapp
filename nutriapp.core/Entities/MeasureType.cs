namespace nutriapp.core.Entities;

public partial class MeasureType : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public double ConversionFactor { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<FoodAtFridge> FoodAtFridges { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumedCookedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodConsumed> FoodConsumedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureCookedMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<WaterConsumed> WaterConsumed { get; set; } = new List<WaterConsumed>();
    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasurePracticalMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<WaterMeasure> WaterMeasures { get; set; } = new List<WaterMeasure>();
}
