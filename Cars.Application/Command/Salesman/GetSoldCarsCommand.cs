using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record GetSoldCarsCommand(string? SalesmanId) : IRequest<List<CarDto>>;

public class GetSoldCarsHandler : IRequestHandler<GetSoldCarsCommand, List<CarDto>>
{
    private readonly IMapper _mapper;

    public GetSoldCarsHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<CarDto>> Handle(GetSoldCarsCommand request, CancellationToken cancellationToken)
    {
        var salesman = (from salesmanEntity in DB.Queryable<SalesmanEntity>()
            where salesmanEntity.ID.Equals(request.SalesmanId)
            select salesmanEntity).First();

        return new List<CarDto>(salesman.CarEntities.Select(x => _mapper.Map<CarDto>(x)));
    }
}