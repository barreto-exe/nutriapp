﻿using nutriapp.business.Base;

namespace nutriapp.business.WaterConsumed;

public class CreateWaterConsumedResponse : BaseCommandResponse
{
    public double LitersLeft { get; set; }
}