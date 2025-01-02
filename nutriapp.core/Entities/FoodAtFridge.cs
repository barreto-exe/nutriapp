namespace nutriapp.core.Entities;

public partial class FoodAtFridge : BaseEntity
{
    public int Id { get; set; }

    public int User { get; set; }

    public int Food { get; set; }

    public double? Quantity { get; set; }

    public int? MeasureType { get; set; }

    public double? CookedQuantity { get; set; }

    public int? CookedMeasureType { get; set; }

    public double? PracticalQuantity { get; set; }

    public int? PracticalMeasureType { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual MeasureType? CookedMeasureTypeNavigation { get; set; }

    public virtual Food FoodNavigation { get; set; } = null!;

    public virtual MeasureType? MeasureTypeNavigation { get; set; }

    public virtual MeasureType? PracticalMeasureTypeNavigation { get; set; }

    public virtual User UserNavigation { get; set; } = null!;
}
