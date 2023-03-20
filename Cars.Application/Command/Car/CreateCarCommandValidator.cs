using FluentValidation;
using MongoDB.Entities;

namespace Cars.Application.Command.Car;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.CarDto.Manufacturer).MaximumLength(64).NotEmpty();
        RuleFor(x => x.CarDto.Model).MaximumLength(64).NotEmpty();
        RuleFor(x => x.CarDto.YearOfMake.GetValueOrDefault().Date).LessThan(DateTime.Today);
        RuleFor(x => x.CarDto.Price).NotEmpty().GreaterThan(0);
    }
}