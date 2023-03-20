using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Command.Car;

public record CreateCarCommand(CarDto CarDto) : IRequest<CarDto>;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    private readonly IMapper _mapper;

    public CreateCarHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<CarEntity>(request.CarDto);
        await car.SaveAsync(cancellation: cancellationToken);

        return _mapper.Map<CarDto>(car);
    }
}