using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record UpdateSalesmanCommand(SalesmanDto SalesmanDto) : IRequest<SalesmanDto>;

public class UpdateSalesmanHandler : IRequestHandler<UpdateSalesmanCommand, SalesmanDto>
{
    private readonly IMapper _mapper;

    public UpdateSalesmanHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SalesmanDto> Handle(UpdateSalesmanCommand request, CancellationToken cancellationToken)
    {
        var salesman = _mapper.Map<SalesmanEntity>(request.SalesmanDto);
        await salesman.SaveAsync(cancellation: cancellationToken);
        
        return _mapper.Map<SalesmanDto>(salesman);
    }
}