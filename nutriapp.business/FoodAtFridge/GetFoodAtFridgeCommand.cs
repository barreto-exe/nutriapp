using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace nutriapp.business.FoodAtFridge;

public class GetFoodAtFridgeCommand : IRequest<GetFoodAtFridgeResponse>
{
    [JsonIgnore]
    [SwaggerSchema(ReadOnly = true, Description = "Ignored")]
    public int User { get; set; }
    public DateTime Date { get; set; }
}