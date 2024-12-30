using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
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
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var measure = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.MeasureType);
        var waterGoal = await waterMeasureService.GetWaterMeasureByUserIdAsync(request.User);

        var response = new CreateWaterConsumedResponse();
        var messages = new List<string>();
        if (user == null)
        {
            response.Success = false;
            messages.Add("User not found");
        }
        if (measure == null)
        {
            response.Success = false;
            messages.Add("Measure type not found");
        }
        if (measure?.Type != "Capacidad")
        {
            response.Success = false;
            messages.Add("Measure type must be 'Capacidad'");
        }
        if (waterGoal == null)
        {
            response.Success = false;
            messages.Add("Water goal not found");
        }
        if (!response.Success)
        {
            response.Message = string.Join("; ", messages);
            return response;
        }

        var waterConsumed = mapper.Map<WaterConsumedEntity>(request);
        await waterConsumedService.CreateWaterConsumedAsync(waterConsumed);

        //Calculate liters consumed today (Convert all to liters with ConversionFactor)
        double litersConsumedToday = waterConsumedService
            .GetWaterConsumedToday(request.User)
            .ToList()
            .Sum(x => x.Quantity * x.MeasureTypeNavigation.ConversionFactor);

        var litersGoal = waterGoal!.Quantity * waterGoal.MeasureTypeNavigation.ConversionFactor;

        return new CreateWaterConsumedResponse()
        {
            LitersLeft = litersGoal - litersConsumedToday
        };
    }
}