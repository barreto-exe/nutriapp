using System;
using System.Collections.Generic;

namespace nutriapp.core.Entities;
public partial class User : BaseEntity
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public virtual ICollection<FoodAtFridge> FoodAtFridges { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumeds { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasures { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<MealType> MealTypes { get; set; } = new List<MealType>();
}
