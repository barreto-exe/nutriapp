using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.infrastructure.Interfaces;

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
        return mapper.Map<GetWaterMeasureResponse>(waterMeasure);
    }
}