using System;
using System.Collections.Generic;

namespace nutriapp.core.Entities;
public partial class UnitMenu : BaseEntity
{
    public int Id { get; set; }

    public int FoodType { get; set; }

    public int MaxQuantity { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual FoodType FoodTypeNavigation { get; set; } = null!;
}
