using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record CreateSalesmanCommand(SalesmanDto SalesmanDto) : IRequest<SalesmanDto>;

public class CreateCarHandler : IRequestHandler<CreateSalesmanCommand, SalesmanDto>
{
    private readonly IMapper _mapper;

    public CreateCarHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SalesmanDto> Handle(CreateSalesmanCommand request, CancellationToken cancellationToken)
    {
        var salesman = _mapper.Map<SalesmanEntity>(request.SalesmanDto);
        await salesman.SaveAsync(cancellation: cancellationToken);

        return _mapper.Map<SalesmanDto>(salesman);
    }
}