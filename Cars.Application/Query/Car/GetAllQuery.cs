using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Cars.Application.Query.Car;

public record GetAllQuery : IRequest<List<CarDto>>;

public class GetAllHandler : IRequestHandler<GetAllQuery, List<CarDto>>
{
    private readonly IMapper _mapper;

    public GetAllHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<CarDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var carDtoList = _mapper.Map<List<CarDto>>(await DB.Fluent<CarEntity>()
            .ToListAsync(cancellationToken: cancellationToken));
        
        return carDtoList;
    }
}