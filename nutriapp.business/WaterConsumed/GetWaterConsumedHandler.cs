using MediatR;
using nutriapp.business.Interfaces;

namespace nutriapp.business.WaterConsumed;

public class GetWaterConsumedHandler : IRequestHandler<GetWaterConsumedCommand, GetWaterConsumedResponse>
{
    private readonly IWaterConsumedService waterConsumedService;
    private readonly IWaterMeasureService waterMeasureService;

    public GetWaterConsumedHandler(IWaterConsumedService waterConsumedService, IWaterMeasureService waterMeasureService)
    {
        this.waterConsumedService = waterConsumedService;
        this.waterMeasureService = waterMeasureService;
    }

    public async Task<GetWaterConsumedResponse> Handle(GetWaterConsumedCommand request, CancellationToken cancellationToken)
    {
        var waterGoal = await waterMeasureService.GetWaterMeasureByUserIdAsync(request.User);
        if (waterGoal == null) return null;

        var waterConsumed = waterConsumedService.GetWaterConsumedToday(request.User);
        double litersConsumedToday = waterConsumedService
            .GetWaterConsumedToday(request.User)
            .ToList()
            .Sum(x => x.Quantity * x.MeasureTypeNavigation.ConversionFactor);

        double litersGoal = waterGoal.Quantity * waterGoal.MeasureTypeNavigation.ConversionFactor;

        return new GetWaterConsumedResponse
        {
            LitersLeft = litersGoal - litersConsumedToday,
            LitersConsumedToday = litersConsumedToday
        };
    }
}
