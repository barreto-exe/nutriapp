using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.FoodsConsumed;

public class GetFoodConsumedHandler : IRequestHandler<GetFoodConsumedCommand, GetFoodConsumedResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetFoodConsumedHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
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

        var foodConsumed = await unitOfWork.FoodConsumedRepository
            .GetAllIncluding("FoodNavigation")
            .Where(fc => fc.User == request.User && fc.UpdatedDate.Date == request.Date.Date)
            .ToListAsync(cancellationToken);

        var food = await unitOfWork.FoodRepository.GetAll().ToListAsync(cancellationToken);
        var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);

        //Group foodConsumed by food and sum quantities (converted to the same measure type)
        var foodConsumedGrouped = foodConsumed
            .GroupBy(fc => fc.FoodNavigation.Name)
            .Select(g => new models.FoodConsumed
            {
                Name = g.Key,

                TotalQuantity = g.Sum(fc => ConverQuantity(fc.Quantity, fc.MeasureTypeNavigation?.ConversionFactor)),
                Measure = GetUnitMeasureName(measures, g.FirstOrDefault()?.MeasureType),

                TotalCookedQuantity = g.Sum(fc => ConverQuantity(fc.CookedQuantity, fc.CookedMeasureTypeNavigation?.ConversionFactor)),
                CookedMeasure = GetUnitMeasureName(measures, g.FirstOrDefault()?.CookedMeasureType),

                TotalPracticalQuantity = g.Sum(fc => ConverQuantity(fc.PracticalQuantity, fc.PracticalMeasureTypeNavigation?.ConversionFactor)),
                PracticalMeasure = GetUnitMeasureName(measures, g.FirstOrDefault()?.PracticalMeasureType)
            });

        response.FoodConsumed = foodConsumedGrouped.ToList();

        //Round Quantities to 2 decimal places
        response.FoodConsumed.ForEach(fc =>
        {
            fc.TotalQuantity = Math.Round(fc.TotalQuantity, 2);
            fc.TotalCookedQuantity = Math.Round(fc.TotalCookedQuantity ?? 0, 2);
            fc.TotalPracticalQuantity = Math.Round(fc.TotalPracticalQuantity ?? 0, 2);
        });

        return response;

        static double ConverQuantity(double? quantity, double? ConversionFactor)
        {
            //Validate null or 0 to avoid null reference exception
            if (quantity == null || ConversionFactor == null || ConversionFactor == 0)
            {
                return 0;
            }

            return quantity.Value * ConversionFactor.Value;
        }
        static string GetUnitMeasureName(List<MeasureType> measures, int? measureTypeId)
        {
            //Validate null to avoid null reference exception
            var measureType = measures.FirstOrDefault(m => m.Id == measureTypeId);
            if (measureType == null)
            {
                return "";
            }

            //Get the measure type with conversion factor 1
            var measureType1 = measures.FirstOrDefault(m => m.Type == measureType.Type && m.ConversionFactor == 1);
            return measureType1?.Abbreviation ?? "";
        }
    }
}