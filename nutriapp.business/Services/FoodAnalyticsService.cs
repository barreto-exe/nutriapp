using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nutriapp.business.Interfaces;
using nutriapp.infrastructure.Interfaces;
using nutriapp.core.Entities;
using FoodAtFridgeEntity = nutriapp.core.Entities.FoodAtFridge;
using static nutriapp.business.Services.FoodAnalyticsService;
using nutriapp.core.Interfaces;


namespace nutriapp.business.Services;

public class FoodAnalyticsService : IFoodAnalyticsService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public enum FoodDataSource
    {
        FoodConsumed,
        FoodAtFridge
    }

    public FoodAnalyticsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<List<models.FoodUnitEquivalent>> GetFoodSumEquivalentAsync(FoodDataSource source, int userId, DateTime date, CancellationToken cancellationToken)
    {
        IQueryable<IConvertibleFoodEntity> foodEquivalentEntities;

        if (source == FoodDataSource.FoodConsumed)
        {
            foodEquivalentEntities = unitOfWork.FoodConsumedRepository
                .GetAllIncluding("FoodNavigation")
                .Where(fc => fc.User == userId && fc.UpdatedDate.Date == date.Date);
        }
        else if (source == FoodDataSource.FoodAtFridge)
        {
            foodEquivalentEntities = unitOfWork.FoodAtFridgeRepository
                .GetAllIncluding("FoodNavigation")
                .Where(fc => fc.User == userId && fc.UpdatedDate.Date == date.Date);
        }
        else
        {
            throw new ArgumentException("Invalid Repository Type");
        }

        var foodEquivalentList = await foodEquivalentEntities.ToListAsync(cancellationToken);

        var measures = await unitOfWork.MeasureTypeRepository.GetAll().ToListAsync(cancellationToken);

        //Group foodConsumed by food and sum quantities (converted to the same base measure type)
        var equivalentResults = foodEquivalentList
            .GroupBy(fc => fc.FoodNavigation)
            .Select(g => GroupAndSumFoodEquivalent(g, measures, date))
            .ToList();

        //Round Quantities to 2 decimal places
        equivalentResults.ForEach(fc =>
        {
            fc.TotalQuantity = Math.Round(fc.TotalQuantity, 2);
            fc.TotalCookedQuantity = Math.Round(fc.TotalCookedQuantity ?? 0, 2);
            fc.TotalPracticalQuantity = Math.Round(fc.TotalPracticalQuantity ?? 0, 2);
            fc.EquivalentUnits = Math.Round(fc.EquivalentUnits, 2);
        });

        return equivalentResults;
    }


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
    private double GetEquivalentUnits(Food food, double totalQuantity, double totalCookedQuantity, double totalPracticalQuantity, DateTime requestDate)
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
    private models.FoodUnitEquivalent GroupAndSumFoodEquivalent(IGrouping<Food, IConvertibleFoodEntity> g, List<MeasureType> measures, DateTime requestDate)
    {
        double totalQuantity = g.Sum(fc => ConverQuantity(fc.Quantity, fc.MeasureTypeNavigation?.ConversionFactor));
        var firstMeasureType = g.FirstOrDefault(x => x.MeasureType != null)?.MeasureType;
        string measure = GetBaseMeasureName(measures, firstMeasureType);
        var measureType = GetBaseMeasure(measures, firstMeasureType);

        double totalCookedQuantity = g.Sum(fc => ConverQuantity(fc.CookedQuantity, fc.CookedMeasureTypeNavigation?.ConversionFactor));
        var firstCookedMeasureType = g.FirstOrDefault(x => x.CookedMeasureType != null)?.CookedMeasureType;
        string cookedMeasure = GetBaseMeasureName(measures, firstCookedMeasureType);
        var cookedMeasureType = GetBaseMeasure(measures, firstCookedMeasureType);

        double totalPracticalQuantity = g.Sum(fc => ConverQuantity(fc.PracticalQuantity, fc.PracticalMeasureTypeNavigation?.ConversionFactor));
        var firstPracticalMeasureType = g.FirstOrDefault(x => x.PracticalMeasureType != null)?.PracticalMeasureType;
        string practicalMeasure = GetBaseMeasureName(measures, firstPracticalMeasureType);
        var practicalMeasureType = GetBaseMeasure(measures, firstPracticalMeasureType);

        return new models.FoodUnitEquivalent
        {
            FoodId = g.Key.Id,
            Name = g.Key.Name,

            TotalQuantity = totalQuantity,
            Measure = measure,

            TotalCookedQuantity = totalCookedQuantity,
            CookedMeasure = cookedMeasure,

            TotalPracticalQuantity = totalPracticalQuantity,
            PracticalMeasure = practicalMeasure,

            EquivalentUnits = GetEquivalentUnits(g.Key, totalQuantity, totalCookedQuantity, totalPracticalQuantity, requestDate.Date)
        };
    }
}