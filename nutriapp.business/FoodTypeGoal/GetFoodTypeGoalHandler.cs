using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;
using nutriapp.models;
using static nutriapp.business.Services.FoodAnalyticsService;

namespace nutriapp.business.FoodTypeGoal;

public class GetFoodTypeGoalHandler : IRequestHandler<GetFoodTypeGoalCommand, GetFoodTypeGoalResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IFoodAnalyticsService foodConsumedService;

    public GetFoodTypeGoalHandler(IUnitOfWork unitOfWork, IMapper mapper, IFoodAnalyticsService foodConsumedService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.foodConsumedService = foodConsumedService;
    }

    public async Task<GetFoodTypeGoalResponse> Handle(GetFoodTypeGoalCommand request, CancellationToken cancellationToken)
    {
        var response = new GetFoodTypeGoalResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var unitMenu = await unitOfWork.UnitMenuRepository
            .GetAllIncluding("FoodTypeNavigation")
            .Where(x => x.User == request.User && x.UpdatedDate.Date <= request.Date.Date)
            .GroupBy(x => x.FoodType)
            .Select(x => x.OrderByDescending(y => y.UpdatedDate).FirstOrDefault())
            .ToListAsync(cancellationToken);


        response.Goals = mapper.Map<List<models.FoodTypeGoal>>(unitMenu);
        response.Goals.ForEach(x => x.LeftQuantity = x.MaxQuantity);

        var food = await unitOfWork.FoodRepository.GetAllIncluding("FoodTypeNavigation").ToListAsync(cancellationToken);
        var foodConsumed = await foodConsumedService.GetFoodSumEquivalentAsync(FoodDataSource.FoodConsumed, request.User, request.Date, cancellationToken);

        foreach(var consumed in foodConsumed)
        {
            var foodType = food.FirstOrDefault(x => x.Id == consumed.FoodId)!.FoodTypeNavigation;
            var goal = response.Goals.FirstOrDefault(x => x.FoodType == foodType.Id);

            if (goal != null)
            {
                goal.ConsumedQuantity += consumed.EquivalentUnits;
                goal.LeftQuantity = goal.MaxQuantity - goal.ConsumedQuantity;
            }
        }

        return response;
    }
}
