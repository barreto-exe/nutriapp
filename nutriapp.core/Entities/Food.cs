namespace nutriapp.core.Entities;

public partial class Food : BaseEntity
{
    public int Id { get; set; }

    public int FoodType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FoodAtFridge> FoodAtFridges { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumeds { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasures { get; set; } = new List<FoodMenuMeasure>();

    public virtual FoodType FoodTypeNavigation { get; set; } = null!;
}
