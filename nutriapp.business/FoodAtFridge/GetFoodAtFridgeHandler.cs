using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using static nutriapp.business.Services.FoodAnalyticsService;

namespace nutriapp.business.FoodAtFridge;

public class GetFoodAtFridgeHandler : IRequestHandler<GetFoodAtFridgeCommand, GetFoodAtFridgeResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IFoodAnalyticsService foodAnalyticsService;

    public GetFoodAtFridgeHandler(IUnitOfWork unitOfWork, IMapper mapper, IFoodAnalyticsService foodAnalyticsService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.foodAnalyticsService = foodAnalyticsService;
    }

    public async Task<GetFoodAtFridgeResponse> Handle(GetFoodAtFridgeCommand request, CancellationToken cancellationToken)
    {
        var response = new GetFoodAtFridgeResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found")
        ]);
        if (!response.Success)
        {
            return response;
        }

        response.FoodAtFridge = await foodAnalyticsService.GetFoodSumEquivalentAsync(FoodDataSource.FoodAtFridge, request.User, request.Date, cancellationToken);

        return response;
    }
}