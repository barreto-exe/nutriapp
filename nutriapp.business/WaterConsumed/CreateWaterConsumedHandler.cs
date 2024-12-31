using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using WaterConsumedEntity = nutriapp.core.Entities.WaterConsumed;

namespace nutriapp.business.WaterConsumed;

public class CreateWaterConsumedHandler : IRequestHandler<CreateWaterConsumedCommand, CreateWaterConsumedResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IWaterConsumedService waterConsumedService;
    private readonly IWaterMeasureService waterMeasureService;
    public CreateWaterConsumedHandler(IUnitOfWork unitOfWork, IMapper mapper, IWaterConsumedService waterConsumedService, IWaterMeasureService waterMeasureService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.waterConsumedService = waterConsumedService;
        this.waterMeasureService = waterMeasureService;
    }

    public async Task<CreateWaterConsumedResponse> Handle(CreateWaterConsumedCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateWaterConsumedResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var measure = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.MeasureType);
        var waterGoal = await waterMeasureService.GetWaterMeasureByUserIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (measure == null, "Measure type not found"),
            (measure?.Type != "Capacidad", "Measure type must be 'Capacidad'"),
            (waterGoal == null, "Water goal not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var waterConsumed = mapper.Map<WaterConsumedEntity>(request);
        await waterConsumedService.CreateWaterConsumedAsync(waterConsumed);

        double litersConsumedToday = waterConsumedService
            .GetWaterConsumedToday(request.User)
            .ToList()
            .Sum(x => x.Quantity / x.MeasureTypeNavigation.ConversionFactor);

        var litersGoal = waterGoal!.Quantity / waterGoal.MeasureTypeNavigation.ConversionFactor;

        return new CreateWaterConsumedResponse()
        {
            LitersLeft = Math.Round(litersGoal - litersConsumedToday, 2),
        };
    }
}