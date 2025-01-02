using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedHandler : IRequestHandler<GetFoodConsumedCommand, GetFoodConsumedResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IFoodConsumedService foodConsumedService;

    public GetFoodConsumedHandler(IUnitOfWork unitOfWork, IMapper mapper, IFoodConsumedService foodConsumedService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.foodConsumedService = foodConsumedService;
    }


    public async Task<GetFoodConsumedResponse> Handle(GetFoodConsumedCommand request, CancellationToken cancellationToken)
    {
        var response = new GetFoodConsumedResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);

        response.AddValidationMessages(
        [
            (user == null, "User not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        response.FoodConsumed = await foodConsumedService.GetFoodConsumedAsync(request.User, request.Date, cancellationToken);

        return response;
    }
}