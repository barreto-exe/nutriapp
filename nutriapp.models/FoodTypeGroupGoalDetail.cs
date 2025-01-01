namespace nutriapp.models;

public class FoodTypeGroupGoalDetail
{
    public int Id { get; set; }
    public MealType MealType { get; set; }
    public FoodTypeGroup FoodTypeGroup { get; set; }
    public int Quantity { get; set; }
    public DateTime UpdatedDate { get; set; }
}