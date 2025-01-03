using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedCommand : IRequest<GetFoodConsumedResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public DateTime Date { get; set; }
}
