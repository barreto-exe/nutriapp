namespace nutriapp.models;

public class FoodConsumed
{
    public string Name { get; set; }
    public double TotalQuantity { get; set; }
    public string Measure { get; set; }
    public double? TotalCookedQuantity { get; set; }
    public string? CookedMeasure { get; set; }
    public double? TotalPracticalQuantity { get; set; }
    public string? PracticalMeasure { get; set; }
    public double EquivalentUnits { get; set; }
}