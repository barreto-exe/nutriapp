using AutoMapper;
using Azure;
using MediatR;
using nutriapp.business.Interfaces;
using nutriapp.business.Services;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.WaterMeasures;

public class CreateWaterMeasureHandler : IRequestHandler<CreateWaterMeasureCommand, CreateWaterMeasureResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IWaterMeasureService waterMeasureService;
    private readonly IMapper mapper;

    public CreateWaterMeasureHandler(IUnitOfWork unitOfWork, IWaterMeasureService waterMeasureService, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.waterMeasureService = waterMeasureService;
        this.mapper = mapper;
    }

    public async Task<CreateWaterMeasureResponse> Handle(CreateWaterMeasureCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateWaterMeasureResponse();

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.User);
        var measureType = await unitOfWork.MeasureTypeRepository.GetByIdAsync(request.MeasureType);

        response.AddValidationMessages(
        [
            (user == null, "User not found"),
            (measureType == null, "Measure type not found"),
            (request.Quantity <= 0, "Quantity must be greater than 0")
        ]);

        if (!response.Success)
        {
            return response;
        }

        var waterMeasure = mapper.Map<WaterMeasure>(request);

        await waterMeasureService.CreateAsync(waterMeasure);

        return response;
    }
}
