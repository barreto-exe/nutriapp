﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;
using static nutriapp.business.Services.FoodAnalyticsService;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedHandler : IRequestHandler<GetFoodConsumedCommand, GetFoodConsumedResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IFoodAnalyticsService foodAnalyticsService;

    public GetFoodConsumedHandler(IUnitOfWork unitOfWork, IMapper mapper, IFoodAnalyticsService foodAnalyticsService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.foodAnalyticsService = foodAnalyticsService;
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

        response.FoodConsumed = await foodAnalyticsService.GetFoodSumEquivalentAsync(FoodDataSource.FoodConsumed, request.User, request.Date, cancellationToken);

        return response;
    }
}