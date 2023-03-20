using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record DeleteSalesmanCommand(SalesmanDto SalesmanDto) : IRequest<SalesmanDto>;

public class DeleteSalesmanHandler : IRequestHandler<DeleteSalesmanCommand, SalesmanDto>
{
    private readonly IMapper _mapper;

    public DeleteSalesmanHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SalesmanDto> Handle(DeleteSalesmanCommand request, CancellationToken cancellationToken)
    {
        var salesman = _mapper.Map<SalesmanEntity>(request.SalesmanDto);
        await DB.DeleteAsync<SalesmanEntity>(salesman.ID, cancellation: cancellationToken);
        
        return _mapper.Map<SalesmanDto>(salesman);
    }
}