namespace nutriapp.models;

public class FoodGoal
{
    public int Id { get; set; }

    public string Food { get; set; }

    public double Quantity { get; set; }

    public string MeasureType { get; set; }

    public double? CookedQuantity { get; set; }

    public string? CookedMeasureType { get; set; }

    public double? PracticalQuantity { get; set; }

    public string? PracticalMeasureType { get; set; }

    public DateTime UpdatedDate { get; set; }
}