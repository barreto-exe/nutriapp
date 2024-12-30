using AutoMapper;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.WaterMeasures;

public class CreateWaterMeasureHandler : IRequestHandler<CreateWaterMeasureCommand, CreateWaterMeasureResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public CreateWaterMeasureHandler(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.userService = userService;
        this.mapper = mapper;
    }

    public async Task<CreateWaterMeasureResponse> Handle(CreateWaterMeasureCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetById(request.UserId);
        var measureType = await unitOfWork.MeasureTypeRepository.GetById(request.MeasureType);

        if (user == null)
        {
            return new CreateWaterMeasureResponse
            {
                Success = false,
                Message = "User not found"
            };
        }
        if (measureType == null)
        {
            return new CreateWaterMeasureResponse
            {
                Success = false,
                Message = "Measure type not found"
            };
        }
        if (request.Quantity <= 0)
        {
            return new CreateWaterMeasureResponse
            {
                Success = false,
                Message = "Quantity must be greater than 0"
            };
        }


        var waterMeasure = mapper.Map<WaterMeasure>(request);

        await unitOfWork.WaterMeasureRepository.Add(waterMeasure);
        await unitOfWork.SaveChangesAsync();

        return new CreateWaterMeasureResponse();
    }
}
