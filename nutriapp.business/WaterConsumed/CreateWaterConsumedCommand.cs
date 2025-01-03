﻿using MediatR;
using System.Text.Json.Serialization;

namespace nutriapp.business.WaterConsumed;

public class CreateWaterConsumedCommand : IRequest<CreateWaterConsumedResponse>
{
    [JsonIgnore]
    public int User { get; set; }
    public double Quantity { get; set; }
    public int MeasureType { get; set; }
}