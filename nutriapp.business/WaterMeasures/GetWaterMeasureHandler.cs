using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.infrastructure.Data;
using nutriapp.models;

namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureHandler : IRequestHandler<GetWaterMeasureCommand, GetWaterMeasureResponse>
{
    private readonly IMapper mapper;
    private readonly IWaterMeasureService waterMeasureService;

    public GetWaterMeasureHandler(IMapper mapper, IWaterMeasureService waterMeasureService)
    {
        this.mapper = mapper;
        this.waterMeasureService = waterMeasureService;
    }

    public async Task<GetWaterMeasureResponse> Handle(GetWaterMeasureCommand request, CancellationToken cancellationToken)
    {
        var waterMeasure = await waterMeasureService.GetWaterMeasureByUserIdAsync(request.UserId);

        //Convert to mililiters
        waterMeasure.Quantity *= waterMeasure.MeasureTypeNavigation.ConversionFactor;
        waterMeasure.MeasureType = SeedData.MeasureTypes
            .FirstOrDefault(m => m.Type == waterMeasure.MeasureTypeNavigation.Type && m.ConversionFactor == 1)!.Id;

        var response = new GetWaterMeasureResponse { WaterMeasure = mapper.Map<WaterMeasure>(waterMeasure) };
        return response;
    }
}