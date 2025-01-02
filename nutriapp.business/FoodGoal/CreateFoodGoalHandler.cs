using AutoMapper;
using MediatR;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodGoal;

public class CreateFoodGoalHandler : IRequestHandler<CreateFoodGoalCommand, CreateFoodGoalResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateFoodGoalHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateFoodGoalResponse> Handle(CreateFoodGoalCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateFoodGoalResponse();

        //If CookedQuantity and PracticalQuantity are 0, assign them to null
        if (request.CookedQuantity == 0)
        {
            request.CookedQuantity = null;
            request.CookedMeasureType = null;
        }
        if (request.PracticalQuantity == 0)
        {
            request.PracticalQuantity = null;
            request.PracticalMeasureType = null;
        }

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var food = await unitOfWork.FoodRepository.GetByIdAsync(request.Food);

        var measureType = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.MeasureType);
        var cookedMeasureType = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.CookedMeasureType);
        var practicalMeasureType = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.PracticalMeasureType);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (food == null, "Food not found"),
            
            (request.Quantity <= 0, "Quantity must be greater than 0"),
            (measureType == null, "MeasureType not found"),
            
            (request.CookedQuantity != null && request.CookedQuantity <= 0, "CookedQuantity must be greater than 0"),
            (request.CookedQuantity != null && cookedMeasureType == null, "CookedMeasureType not found"),

            (request.PracticalQuantity != null && request.PracticalQuantity <= 0, "PracticalQuantity must be greater than 0"),
            (request.PracticalQuantity != null && practicalMeasureType == null, "PracticalMeasureType not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var foodGoal = mapper.Map<FoodMenuMeasure>(request);

        foodGoal.UpdatedDate = DateTime.Now;

        await unitOfWork.FoodMenuMeasureRepository.AddAsync(foodGoal);
        await unitOfWork.SaveChangesAsync();

        return response;
    }
}