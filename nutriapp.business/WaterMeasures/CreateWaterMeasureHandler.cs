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
    private readonly IWaterMeasureService waterMeasureService;
    private readonly IMapper mapper;

    public CreateWaterMeasureHandler(IUnitOfWork unitOfWork, IUserService userService, IWaterMeasureService waterMeasureService, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.userService = userService;
        this.waterMeasureService = waterMeasureService;
        this.mapper = mapper;
    }

    public async Task<CreateWaterMeasureResponse> Handle(CreateWaterMeasureCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetByIdAsync(request.User);
        var measureType = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.MeasureType);

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

        await waterMeasureService.CreateAsync(waterMeasure);

        return new CreateWaterMeasureResponse();
    }
}
