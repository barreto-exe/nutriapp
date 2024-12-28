using System;
using System.Collections.Generic;

namespace nutriapp.core.Entities;
public partial class FoodType : BaseEntity
{
    public int Id { get; set; }

    public int FoodTypeGroup { get; set; }

    public string Name { get; set; } = null!;

    public virtual FoodTypeGroup FoodTypeGroupNavigation { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<UnitMenu> UnitMenus { get; set; } = new List<UnitMenu>();
}
