using AutoMapper;
using MediatR;
using nutriapp.infrastructure.Interfaces;

namespace nutriapp.business.WaterMeasures;

public class GetWaterMeasureHandler : IRequestHandler<GetWaterMeasureCommand, GetWaterMeasureResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetWaterMeasureHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetWaterMeasureResponse> Handle(GetWaterMeasureCommand request, CancellationToken cancellationToken)
    {
        var waterMeasure = unitOfWork.WaterMeasureRepository
            .GetAllIncluding(x => x.UserNavigation)
            .Where(x => x.UserNavigation.Id == request.UserId)
            .OrderByDescending(x => x.UpdatedDate)
            .Take(1)
            .FirstOrDefault();

        return mapper.Map<GetWaterMeasureResponse>(waterMeasure);
    }
}