namespace nutriapp.models;

public class FoodTypeGoal
{
    public int FoodType { get; set; }
    public string Name { get; set; }
    public int MaxQuantity { get; set; }
    public double ConsumedQuantity { get; set; }
    public double LeftQuantity { get; set; }
}
