namespace nutriapp.core.Entities;
public partial class MealType : BaseEntity
{
    public int Id { get; set; }

    public int User { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupUnitMenu> GroupUnitMenus { get; set; } = new List<GroupUnitMenu>();

    public virtual User UserNavigation { get; set; } = null!;
}
