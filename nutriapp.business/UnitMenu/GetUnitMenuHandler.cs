using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;
using nutriapp.models;

namespace nutriapp.business.UnitMenu;

public class GetUnitMenuHandler : IRequestHandler<GetUnitMenuCommand, GetUnitMenuResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetUnitMenuHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetUnitMenuResponse> Handle(GetUnitMenuCommand request, CancellationToken cancellationToken)
    {
        var response = new GetUnitMenuResponse();

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
