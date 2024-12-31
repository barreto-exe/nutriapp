using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodsConsumed;

public class CreateFoodConsumedHandler : IRequestHandler<CreateFoodConsumedCommand, CreateFoodConsumedResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateFoodConsumedHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateFoodConsumedResponse> Handle(CreateFoodConsumedCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateFoodConsumedResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var food = await unitOfWork.FoodRepository.GetByIdAsync(request.Food);
        var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);

        //Validate each measure from command.
        //They must be the same type from previous registered measures of the day
        var foodConsumedByUserToday = await unitOfWork.FoodConsumedRepository
            .GetAllIncluding("MeasureTypeNavigation", "CookedMeasureTypeNavigation", "PracticalMeasureTypeNavigation")
            .Where(fc => fc.User == request.User && fc.UpdatedDate.Date == DateTime.Now.Date)
            .ToListAsync(cancellationToken);

        var measureType = measures.FirstOrDefault(m => m.Id == request.MeasureType);
        var isMeasureTypeValid = foodConsumedByUserToday.All(fc => fc.MeasureTypeNavigation.Type == measureType?.Type);

        var cookedMeasureType = measures.FirstOrDefault(m => m.Id == request.CookedMeasureType);
        var isCookedMeasureTypeValid = foodConsumedByUserToday.All(fc => fc.CookedMeasureTypeNavigation?.Type == cookedMeasureType?.Type);

        var practicalMeasureType = measures.FirstOrDefault(m => m.Id == request.PracticalMeasureType);
        var isPracticalMeasureTypeValid = foodConsumedByUserToday.All(fc => fc.PracticalMeasureTypeNavigation?.Type == practicalMeasureType?.Type);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (food == null, "Food not found"),
            (request.Quantity <= 0 && request.CookedQuantity <= 0, "Quantity or CookedQuantity must be greater than 0"),
            (request.Quantity != 0 && request.CookedQuantity != 0, "Quantity and CookedQuantity are exclusive"),
            (measures.All(m => m.Id != request.MeasureType), "Measure type not found"),
            (request.CookedQuantity > 0 && measures.All(m => m.Id != request.CookedMeasureType), "Cooked measure type not found"),
            (request.PracticalQuantity > 0 && measures.All(m => m.Id != request.PracticalMeasureType), "Practical measure type not found"),
            (request.Quantity > 0 && !isMeasureTypeValid, "Measure must be the same type from previous registered measures of the day"),
            (request.CookedQuantity > 0 && !isCookedMeasureTypeValid, "Cooked measure must be the same type from previous registered measures of the day"),
            (request.PracticalQuantity > 0 && !isPracticalMeasureTypeValid, "Practical measure must be the same type from previous registered measures of the day")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var foodConsumed = mapper.Map<FoodConsumed>(request);

        foodConsumed.UpdatedDate = DateTime.Now;

        if (foodConsumed.CookedQuantity == 0)
        {
            foodConsumed.CookedQuantity = null;
            foodConsumed.CookedMeasureType = null;
        }
        if (foodConsumed.PracticalQuantity == 0)
        {
            foodConsumed.PracticalQuantity = null;
            foodConsumed.PracticalMeasureType = null;
        }

        await unitOfWork.FoodConsumedRepository.AddAsync(foodConsumed);
        await unitOfWork.SaveChangesAsync();

        return response;
    }
}