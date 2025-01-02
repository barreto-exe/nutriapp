using AutoMapper;
using MediatR;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodAtFridge;

public class CreateFoodAtFridgeHandler : IRequestHandler<CreateFoodAtFridgeCommand, CreateFoodAtFridgeResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateFoodAtFridgeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateFoodAtFridgeResponse> Handle(CreateFoodAtFridgeCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateFoodAtFridgeResponse();

        if (request.Quantity == 0)
        {
            request.Quantity = null;
            request.MeasureType = null;
        }
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

            (request.Quantity != null && request.Quantity <= 0, "Quantity must be greater than 0"),
            (request.Quantity != null && measureType == null, "MeasureType not found"),

            (request.CookedQuantity != null && request.CookedQuantity <= 0, "CookedQuantity must be greater than 0"),
            (request.CookedQuantity != null && cookedMeasureType == null, "CookedMeasureType not found"),

            (request.PracticalQuantity != null && request.PracticalQuantity <= 0, "PracticalQuantity must be greater than 0"),
            (request.PracticalQuantity != null && practicalMeasureType == null, "PracticalMeasureType not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var foodAtFridge = mapper.Map<core.Entities.FoodAtFridge>(request);

        foodAtFridge.UpdatedDate = DateTime.Now;

        await unitOfWork.FoodAtFridgeRepository.AddAsync(foodAtFridge);
        await unitOfWork.SaveChangesAsync();

        return response;
    }
}
