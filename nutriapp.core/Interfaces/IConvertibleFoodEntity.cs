using nutriapp.core.Entities;

namespace nutriapp.core.Interfaces;

public interface IConvertibleFoodEntity
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

    public MeasureType? CookedMeasureTypeNavigation { get; set; }

    public Food FoodNavigation { get; set; }

    public MeasureType? MeasureTypeNavigation { get; set; }

    public MeasureType? PracticalMeasureTypeNavigation { get; set; }

    public User UserNavigation { get; set; }
}