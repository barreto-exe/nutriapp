namespace nutriapp.core.Entities;

public partial class WaterConsumed : BaseEntity
{
    public int Id { get; set; }

    public int User { get; set; }

    public double Quantity { get; set; }

    public int MeasureType { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual MeasureType MeasureTypeNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;
}
