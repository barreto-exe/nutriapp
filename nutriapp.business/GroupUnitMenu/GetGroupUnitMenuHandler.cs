using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using GroupUnitMenuModel = nutriapp.models.GroupUnitMenu;

namespace nutriapp.business.GroupUnitMenu;

public class GetGroupUnitMenuHandler : IRequestHandler<GetGroupUnitMenuCommand, GetGroupUnitMenuResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetGroupUnitMenuHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetGroupUnitMenuResponse> Handle(GetGroupUnitMenuCommand request, CancellationToken cancellationToken)
    {
        var response = new GetGroupUnitMenuResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        //Select only those that are the most recent for its MealType and FoodTypeGroup
        var groupUnitMenuList = await unitOfWork.GroupUnitMenuRepository
            .GetAllIncluding("MealTypeNavigation", "FoodTypeGroupNavigation")
            .Where(gum => gum.MealTypeNavigation.User == request.User)
            .GroupBy(gum => new { gum.MealType, gum.FoodTypeGroup })
            .Select(gum => gum.OrderByDescending(g => g.UpdatedDate).FirstOrDefault())
            .ToListAsync(cancellationToken);

        response.GroupUnitMenu = mapper.Map<List<GroupUnitMenuModel>>(groupUnitMenuList);

        return response;
    }
}