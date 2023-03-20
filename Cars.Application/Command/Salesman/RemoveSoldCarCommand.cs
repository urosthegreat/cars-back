using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record RemoveSoldCarCommand(string? SoldCarId, string? SalesmanId) : IRequest<SalesmanDto>;

public class RemoveSoldCarHandler : IRequestHandler<RemoveSoldCarCommand, SalesmanDto>
{
    private readonly IMapper _mapper;

    public RemoveSoldCarHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SalesmanDto> Handle(RemoveSoldCarCommand request, CancellationToken cancellationToken)
    {
        var soldCar = (from car in DB.Queryable<CarEntity>()
            where car.ID.Equals(request.SoldCarId)
            select car).FirstOrDefault();

        var salesmanToAddTheCar = (from salesman in DB.Queryable<SalesmanEntity>()
            where salesman.ID.Equals(request.SalesmanId)
            select salesman).FirstOrDefault();

        if (salesmanToAddTheCar != null && soldCar != null)
            await salesmanToAddTheCar.CarEntities.RemoveAsync(soldCar, cancellation: cancellationToken);

        return _mapper.Map<SalesmanDto>(salesmanToAddTheCar);
    }
}