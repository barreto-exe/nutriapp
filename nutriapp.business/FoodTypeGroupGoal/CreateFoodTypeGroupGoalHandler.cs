using AutoMapper;
using MediatR;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using GroupUnitMenuEntity = nutriapp.core.Entities.GroupUnitMenu;


namespace nutriapp.business.FoodTypeGroupGoal
{
    public class CreateFoodTypeGroupGoalHandler : IRequestHandler<CreateFoodTypeGroupGoalCommand, CreateFoodTypeGroupGoalResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateFoodTypeGroupGoalHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CreateFoodTypeGroupGoalResponse> Handle(CreateFoodTypeGroupGoalCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateFoodTypeGroupGoalResponse();

            var mealType = await unitOfWork.MealTypeRepository.GetByIdAsync(request.MealType);
            var foodTypeGroup = await unitOfWork.FoodTypeGroupRepository.GetByIdAsync(request.FoodTypeGroup);

            response.AddValidationMessages(
            [
                (mealType == null, "Meal type not found"),
                (foodTypeGroup == null, "Food type group not found")
            ]);

            if (!response.Success)
            {
                return response;
            }

            var groupUnitMenu = mapper.Map<GroupUnitMenuEntity>(request);

            groupUnitMenu.UpdatedDate = DateTime.Now;

            await unitOfWork.GroupUnitMenuRepository.AddAsync(groupUnitMenu);
            await unitOfWork.SaveChangesAsync();

            return response;
        }
    }
}