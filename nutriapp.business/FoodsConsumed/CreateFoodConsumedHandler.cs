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
        var food = await unitOfWork.FoodRepository
            .GetAllIncluding("MeasureTypes")
            .Where(f => f.Id == request.Food)
            .FirstOrDefaultAsync(cancellationToken);
        var foodGoal = await unitOfWork.FoodMenuMeasureRepository
            .GetAllIncluding("MeasureTypeNavigation", "CookedMeasureTypeNavigation", "PracticalMeasureTypeNavigation")
            .Where(fmm => fmm.Food == request!.Food)
            .OrderByDescending(fmm => fmm.UpdatedDate)
            .FirstOrDefaultAsync(cancellationToken);

        bool isRequestValid = true;
        bool isMeasuresValid = true;
        if (food != null && user != null && foodGoal != null)
        {
            //Validate that quantity, cookedQuantity and practicalQuantity are exclusive to each other
            bool isQuantityValid = request.Quantity.HasValue && request.Quantity.Value > 0;
            bool isCookedQuantityValid = request.CookedQuantity.HasValue && request.CookedQuantity.Value > 0;
            bool isPracticalQuantityValid = request.PracticalQuantity.HasValue && request.PracticalQuantity.Value > 0;
            isRequestValid = isQuantityValid ^ isCookedQuantityValid ^ isPracticalQuantityValid;

            if (isRequestValid)
            {
                //Null everything if equal to 0
                if (request?.Quantity == 0) request.Quantity = null;
                if (request?.MeasureType == 0) request.MeasureType = null;
                if (request?.CookedQuantity == 0) request.CookedQuantity = null;
                if (request?.CookedMeasureType == 0) request.CookedMeasureType = null;
                if (request?.PracticalQuantity == 0) request.PracticalQuantity = null;
                if (request?.PracticalMeasureType == 0) request.PracticalMeasureType = null;

                var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);
                
                var resquestNormalMeasureType = measures.Where(m => m.Id == request?.MeasureType).FirstOrDefault()?.Type;
                var foodGoalNormalMeasureType = measures.Where(m => m.Id == foodGoal.MeasureType).FirstOrDefault()?.Type;
                
                var resquestCookedMeasureType = measures.Where(m => m.Id == request?.CookedMeasureType).FirstOrDefault()?.Type;
                var foodGoalCookedMeasureType = measures.Where(m => m.Id == foodGoal.CookedMeasureType).FirstOrDefault()?.Type;

                var resquestPracticalMeasureType = measures.Where(m => m.Id == request?.PracticalMeasureType).FirstOrDefault()?.Type;
                var foodGoalPracticalMeasureType = measures.Where(m => m.Id == foodGoal.PracticalMeasureType).FirstOrDefault()?.Type;

                //Measures must coincide with the food's goal
                bool isNormalMeasureValid = request?.MeasureType == null || 
                    (isQuantityValid && resquestNormalMeasureType == foodGoalNormalMeasureType);

                bool isCookedMeasureValid = request?.CookedMeasureType == null ||
                    (isCookedQuantityValid & resquestCookedMeasureType == foodGoalCookedMeasureType);

                bool isPracticalMeasureValid = request?.PracticalMeasureType == null ||
                    (isPracticalQuantityValid && resquestPracticalMeasureType == foodGoalPracticalMeasureType);

                isMeasuresValid = isRequestValid && isNormalMeasureValid && isCookedMeasureValid && isPracticalMeasureValid;
            }
        }

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (food == null, "Food not found"),
            (foodGoal == null, "Food goal not found for that food"),
            (!isRequestValid, "Quantity, CookedQuantity and PracticalQuantity are exclusive to each other"),
            (!isMeasuresValid, "Measures must be provided, exclusive and correspond for that food goal. Also, the food goal must exist.")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var foodConsumed = mapper.Map<FoodConsumed>(request);

        foodConsumed.UpdatedDate = DateTime.Now;

        await unitOfWork.FoodConsumedRepository.AddAsync(foodConsumed);
        await unitOfWork.SaveChangesAsync();

        return response;
    }
}