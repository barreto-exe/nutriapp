using AutoMapper;
using MediatR;
using nutriapp.infrastructure.Interfaces;
using nutriapp.models;

namespace nutriapp.business.MealTypes;

public class GetMealTypesHandler : IRequestHandler<GetMealTypesCommand, GetMealTypesResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetMealTypesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetMealTypesResponse> Handle(GetMealTypesCommand request, CancellationToken cancellationToken)
    {
        var mealTypes = unitOfWork.MealTypeRepository
            .GetAllIncluding("GroupUnitMenus", "GroupUnitMenus.FoodTypeGroupNavigation")
            .Where(x => x.User == request.User)
            .ToList();

        //Select only those GroupUnitMenus that are the most recent for its MealType and FoodTypeGroup
        foreach (var mealType in mealTypes)
        {
            mealType.GroupUnitMenus = mealType.GroupUnitMenus
                .GroupBy(gum => gum.FoodTypeGroup)
                .Select(gum => gum.OrderByDescending(g => g.UpdatedDate).FirstOrDefault())
                .ToList();
        }

        var mappedMealTypes = mapper.Map<IEnumerable<MealType>>(mealTypes);

        return new GetMealTypesResponse { MealTypes = mappedMealTypes };
    }
}