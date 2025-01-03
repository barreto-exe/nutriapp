using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodMenuMeasure;

public class GetFoodMenuMeasureCommand : IRequest<GetFoodMenuMeasureResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public DateTime Date { get; set; }
}