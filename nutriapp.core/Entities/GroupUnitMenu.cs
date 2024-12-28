using System;
using System.Collections.Generic;

namespace nutriapp.core.Entities;
public partial class GroupUnitMenu : BaseEntity
{
    public int Id { get; set; }

    public int MealType { get; set; }

    public int FoodTypeGroup { get; set; }

    public int Quantity { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual FoodTypeGroup FoodTypeGroupNavigation { get; set; } = null!;

    public virtual MealType MealTypeNavigation { get; set; } = null!;
}
