using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodMenuMeasure;

public class GetFoodMenuMeasureHandler : IRequestHandler<GetFoodMenuMeasurelCommand, GetFoodMenuMeasureResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetFoodMenuMeasureHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetFoodMenuMeasureResponse> Handle(GetFoodMenuMeasurelCommand request, CancellationToken cancellationToken)
    {
        var response = new GetFoodMenuMeasureResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        //Just take the most recent food goal for each food
        var foodGoalsGrouped = await unitOfWork.FoodMenuMeasureRepository
            .GetAllIncluding("UserNavigation", "FoodNavigation", "MeasureTypeNavigation", "CookedMeasureTypeNavigation", "PracticalMeasureTypeNavigation")
            .Where(x => x.User == request.User && x.UpdatedDate.Date <= request.Date.Date)
            .OrderByDescending(x => x.UpdatedDate)
            .ToListAsync(cancellationToken);

        var foodGoals = foodGoalsGrouped
            .GroupBy(x => x.Food)
            .Select(x => x.FirstOrDefault());

        response.Goals = mapper.Map<IEnumerable<models.FoodGoal>>(foodGoals);

        return response;
    }
}