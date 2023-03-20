using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Cars.Application.Query.Salesman;

public record GetAllQuery : IRequest<List<SalesmanDto>>;

public class GetAllHandler : IRequestHandler<GetAllQuery, List<SalesmanDto>>
{
    private readonly IMapper _mapper;

    public GetAllHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<SalesmanDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var salesmanDtoList = _mapper.Map<List<SalesmanDto>>(await DB.Fluent<SalesmanEntity>()
            .ToListAsync(cancellationToken: cancellationToken));

        return salesmanDtoList;
    }
}