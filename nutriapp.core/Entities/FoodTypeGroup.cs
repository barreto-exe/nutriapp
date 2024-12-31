namespace nutriapp.core.Entities;
public partial class FoodTypeGroup : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FoodType> FoodTypes { get; set; } = new List<FoodType>();

    public virtual ICollection<GroupUnitMenu> GroupUnitMenus { get; set; } = new List<GroupUnitMenu>();
}
