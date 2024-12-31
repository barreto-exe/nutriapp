namespace nutriapp.models;

public class MealType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<FoodTypeGroupQuantity>? FoodTypeGroupMenu { get; set; }
}
