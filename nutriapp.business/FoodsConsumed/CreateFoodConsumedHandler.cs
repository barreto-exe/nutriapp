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
        var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);


        bool isRequestValid = true;
        bool isMeasuresValid = true;
        if (food != null && user != null) 
        {
            //Validate that quantity, cookedQuantity and practicalQuantity are exclusive to each other
            bool isQuantityValid = request.Quantity.HasValue && request.Quantity.Value > 0;
            bool isCookedQuantityValid = request.CookedQuantity.HasValue && request.CookedQuantity.Value > 0;
            bool isPracticalQuantityValid = request.PracticalQuantity.HasValue && request.PracticalQuantity.Value > 0;
            isRequestValid = isQuantityValid ^ isCookedQuantityValid ^ isPracticalQuantityValid;

            if (isRequestValid)
            {
                var validCategories = food.MeasureTypes.Select(mt => mt.Type).ToList();
                var validMeasures = food.MeasureTypes.Select(mt => mt.Id).ToList();

                //Add all measures that are not in the food.MeasureTypes and have the validCategories
                foreach (var measure in measures)
                {
                    if (!validMeasures.Contains(measure.Id) && validCategories.Contains(measure.Type))
                    {
                        validMeasures.Add(measure.Id);
                    }
                }

                //Null everything if equal to 0
                if (request?.Quantity == 0) request.Quantity = null;
                if (request?.MeasureType == 0) request.MeasureType = null;
                if (request?.CookedQuantity == 0) request.CookedQuantity = null;
                if (request?.CookedMeasureType == 0) request.CookedMeasureType = null;
                if (request?.PracticalQuantity == 0) request.PracticalQuantity = null;
                if (request?.PracticalMeasureType == 0) request.PracticalMeasureType = null;

                //Measures must exist inside food.MeasureTypes in case they are provided
                bool isMeasureValid = request?.MeasureType == null || 
                    (isQuantityValid && validMeasures.Contains(request!.MeasureType!.Value));
                bool isCookedMeasureValid = request?.CookedMeasureType == null || 
                    (isCookedQuantityValid && validMeasures.Contains(request!.CookedMeasureType!.Value));
                bool isPracticalMeasureValid = request?.PracticalMeasureType == null || 
                    (isPracticalQuantityValid && validMeasures.Contains(request!.PracticalMeasureType!.Value));

                isMeasuresValid = isRequestValid && isMeasureValid && isCookedMeasureValid && isPracticalMeasureValid;
            }
        }

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (food == null, "Food not found"),
            (!isRequestValid, "Quantity, CookedQuantity and PracticalQuantity are exclusive to each other"),
            (!isMeasuresValid, "Measures must be provided, exclusive and correspond for that food")
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