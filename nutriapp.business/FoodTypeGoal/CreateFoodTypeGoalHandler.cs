using AutoMapper;
using MediatR;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using UnitMenuEntity = nutriapp.core.Entities.UnitMenu;

namespace nutriapp.business.FoodTypeGoal;

public class CreateFoodTypeGoalHandler : IRequestHandler<CreateFoodTypeGoalCommand, CreateFoodTypeGoalResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateFoodTypeGoalHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateFoodTypeGoalResponse> Handle(CreateFoodTypeGoalCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateFoodTypeGoalResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var foodType = await unitOfWork.FoodTypeRepository.GetByIdAsync(request.FoodType);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (foodType == null, "FoodType not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var unitMenu = mapper.Map<UnitMenuEntity>(request);
        unitMenu.UpdatedDate = DateTime.Now;

        await unitOfWork.UnitMenuRepository.AddAsync(unitMenu);
        await unitOfWork.SaveChangesAsync();

        return response;
    }
}
