using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.WaterConsumed;

public class CreateWaterConsumedHandler : IRequestHandler<CreateWaterConsumedCommand, CreateWaterConsumedResponse>
{
    private readonly IWaterConsumedService waterConsumedService;
    private readonly IMapper mapper;

    public CreateWaterConsumedHandler(IWaterConsumedService waterConsumedService, IMapper mapper)
    {
        this.waterConsumedService = waterConsumedService;
        this.mapper = mapper;
    }

    public async Task<CreateWaterConsumedResponse> Handle(CreateWaterConsumedCommand request, CancellationToken cancellationToken)
    {
        //TODO - Validator service

        var waterConsumed = mapper.Map<WaterConsumedEntity>(request);
        await waterConsumedService.CreateWaterConsumedAsync(waterConsumed);

        //TODO - Return water to consume left

        return new CreateWaterConsumedResponse();
    }
}