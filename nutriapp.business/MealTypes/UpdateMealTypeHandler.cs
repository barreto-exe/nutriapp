using AutoMapper;
using MediatR;
using nutriapp.business.Services;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.MealTypes;

public class UpdateMealTypeHandler : IRequestHandler<UpdateMealTypeCommand, UpdateMealTypeResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateMealTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<UpdateMealTypeResponse> Handle(UpdateMealTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateMealTypeResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var meal = await unitOfWork.MealTypeRepository.GetByIdAsync(request.Meal);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (meal == null, "Meal type not found")
        ]);

        if (!response.Success)
        {
            return response;
        }

        meal!.Name = request.Name;

        unitOfWork.MealTypeRepository.Update(meal);
        await unitOfWork.SaveChangesAsync();

        return new UpdateMealTypeResponse();
    }
}