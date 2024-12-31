namespace nutriapp.core.Entities;

public partial class User : BaseEntity
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<FoodAtFridge> FoodAtFridges { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumed { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasures { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<MealType> MealTypes { get; set; } = new List<MealType>();

    public virtual ICollection<WaterConsumed> WaterConsumed { get; set; } = new List<WaterConsumed>();

    public virtual ICollection<UnitMenu> UnitMenus { get; set; } = new List<UnitMenu>();

    public virtual ICollection<WaterMeasure> WaterMeasures { get; set; } = new List<WaterMeasure>();
}
