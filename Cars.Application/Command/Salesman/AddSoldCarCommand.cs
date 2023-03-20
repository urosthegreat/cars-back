using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public record AddSoldCarCommand(string? SoldCarId, string? SalesmanId) : IRequest<SalesmanDto>;

public class AddSoldCarHandler : IRequestHandler<AddSoldCarCommand, SalesmanDto>
{
    private readonly IMapper _mapper;

    public AddSoldCarHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SalesmanDto> Handle(AddSoldCarCommand request, CancellationToken cancellationToken)
    {
        var soldCar = (from car in DB.Queryable<CarEntity>()
            where car.ID.Equals(request.SoldCarId)
            select car).FirstOrDefault();

        var salesmanToAddTheCar = (from salesman in DB.Queryable<SalesmanEntity>()
            where salesman.ID.Equals(request.SalesmanId)
            select salesman).FirstOrDefault();

        if (salesmanToAddTheCar != null && soldCar != null)
            await salesmanToAddTheCar.CarEntities.AddAsync(soldCar, cancellation: cancellationToken);

        return _mapper.Map<SalesmanDto>(salesmanToAddTheCar);
    }
}