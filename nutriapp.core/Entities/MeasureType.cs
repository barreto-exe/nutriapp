using System;
using System.Collections.Generic;

namespace nutriapp.core.Entities;
public partial class MeasureType : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FoodAtFridge> FoodAtFridges { get; set; } = new List<FoodAtFridge>();

    public virtual ICollection<FoodConsumed> FoodConsumedCookedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodConsumed> FoodConsumedMeasureTypeNavigations { get; set; } = new List<FoodConsumed>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureCookedMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();

    public virtual ICollection<FoodMenuMeasure> FoodMenuMeasureMeasureTypeNavigations { get; set; } = new List<FoodMenuMeasure>();
}
