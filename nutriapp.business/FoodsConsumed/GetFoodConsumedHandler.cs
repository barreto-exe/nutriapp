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

        var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);

        //Group foodConsumed by food and sum quantities (converted to the same base measure type)
        var foodConsumedGrouped = foodConsumed
            .GroupBy(fc => fc.FoodNavigation)
            .Select(g =>
            {
                double totalQuantity = g.Sum(fc => ConverQuantity(fc.Quantity, fc.MeasureTypeNavigation?.ConversionFactor));
                var firstMeasureType = g.FirstOrDefault(x => x.MeasureType != null)?.MeasureType;
                string measure  = GetBaseMeasureName(measures, firstMeasureType);
                var measureType = GetBaseMeasure(measures, firstMeasureType);

                double totalCookedQuantity = g.Sum(fc => ConverQuantity(fc.CookedQuantity, fc.CookedMeasureTypeNavigation?.ConversionFactor));
                var firstCookedMeasureType = g.FirstOrDefault(x => x.CookedMeasureType != null)?.CookedMeasureType;
                string cookedMeasure  = GetBaseMeasureName(measures, firstCookedMeasureType);
                var cookedMeasureType = GetBaseMeasure(measures, firstCookedMeasureType);

                double totalPracticalQuantity = g.Sum(fc => ConverQuantity(fc.PracticalQuantity, fc.PracticalMeasureTypeNavigation?.ConversionFactor));
                var firstPracticalMeasureType = g.FirstOrDefault(x => x.PracticalMeasureType != null)?.PracticalMeasureType;
                string practicalMeasure  = GetBaseMeasureName(measures, firstPracticalMeasureType);
                var practicalMeasureType = GetBaseMeasure(measures, firstPracticalMeasureType);

                var foo = new models.FoodConsumed
                {
                    Name = g.Key.Name,

                    TotalQuantity = totalQuantity,
                    Measure = measure,

                    TotalCookedQuantity = totalCookedQuantity,
                    CookedMeasure = cookedMeasure,

                    TotalPracticalQuantity = totalPracticalQuantity,
                    PracticalMeasure = practicalMeasure,

                    EquivalentUnits = GetEquivalentUnits(g.Key, totalQuantity, totalCookedQuantity, totalPracticalQuantity, request.Date)
                };

                return foo;
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
        static string GetBaseMeasureName(List<MeasureType> measures, int? measureTypeId)
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
        static MeasureType? GetBaseMeasure(List<MeasureType> measures, int? measureTypeId)
        {
            //Validate null to avoid null reference exception
            var measureType = measures.FirstOrDefault(m => m.Id == measureTypeId);
            if (measureType == null)
            {
                return null;
            }

            //Get the measure type with conversion factor 1
            var measureType1 = measures.FirstOrDefault(m => m.Type == measureType.Type && m.ConversionFactor == 1);
            return measureType1;
        }
        double GetEquivalentUnits(Food food, double totalQuantity, double totalCookedQuantity, double totalPracticalQuantity, DateTime requestDate)
        {
            var foodGoal = unitOfWork.FoodMenuMeasureRepository
                .GetAllIncluding("MeasureTypeNavigation", "CookedMeasureTypeNavigation", "PracticalMeasureTypeNavigation")
                .Where(fmm => fmm.Food == food.Id && fmm.UpdatedDate.Date <= requestDate.Date.Date)
                .FirstOrDefault();

            if (foodGoal == null)
            {
                return 0;
            }

            var quatityGoal = ConverQuantity(foodGoal.Quantity, foodGoal.MeasureTypeNavigation?.ConversionFactor);
            var cookedQuantityGoal = ConverQuantity(foodGoal.CookedQuantity, foodGoal.CookedMeasureTypeNavigation?.ConversionFactor);
            var practicalQuantityGoal = ConverQuantity(foodGoal.PracticalQuantity, foodGoal.PracticalMeasureTypeNavigation?.ConversionFactor);

            //Sum to total if different from 0
            double total = 0;
            if (quatityGoal != 0)
            {
                total += totalQuantity / quatityGoal;
            }
            if (cookedQuantityGoal != 0)
            {
                total += totalCookedQuantity / cookedQuantityGoal;
            }
            if (practicalQuantityGoal != 0)
            {
                total += totalPracticalQuantity / practicalQuantityGoal;
            }

            return Math.Round(total, 2);
        }
    }
}