namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureResponse : BaseResponse
{
    public double Quantity { get; set; }
    public int MeasureType { get; set; }
}