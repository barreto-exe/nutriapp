using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using nutriapp.models;

namespace nutriapp.business.FoodTypeGoal;

public class GetFoodTypeGoalHandler : IRequestHandler<GetFoodTypeGoalCommand, GetFoodTypeGoalResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetFoodTypeGoalHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
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
            .Where(x => x.User == request.User)
            .GroupBy(x => x.FoodType)
            .Select(x => x.OrderByDescending(y => y.UpdatedDate).FirstOrDefault())
            .ToListAsync(cancellationToken);

        response.UnitMenu = mapper.Map<IEnumerable<FoodTypeQuantity>>(unitMenu);

        return response;
    }
}
