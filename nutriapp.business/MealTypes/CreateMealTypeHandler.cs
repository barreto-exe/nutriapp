using AutoMapper;
using MediatR;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.MealTypes;

public class CreateMealTypeHandler : IRequestHandler<CreateMealTypeCommand, CreateMealTypeResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateMealTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateMealTypeResponse> Handle(CreateMealTypeCommand request, CancellationToken cancellationToken)
    {
        var mealEntity = mapper.Map<MealType>(request);

        await unitOfWork.MealTypeRepository.AddAsync(mealEntity);
        await unitOfWork.SaveChangesAsync();

        return new CreateMealTypeResponse();
    }
}
