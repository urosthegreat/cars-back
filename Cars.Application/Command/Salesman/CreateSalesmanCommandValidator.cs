using FluentValidation;
using MongoDB.Entities;

namespace Cars.Application.Command.Salesman;

public class CreateSalesmanCommandValidator : AbstractValidator<CreateSalesmanCommand>
{
    public CreateSalesmanCommandValidator()
    {
        RuleFor(x => x.SalesmanDto.FirstName).MaximumLength(64).NotEmpty();
        RuleFor(x => x.SalesmanDto.LastName).MaximumLength(64).NotEmpty();
        RuleFor(x => x.SalesmanDto.Email)
            .MaximumLength(512)
            .NotEmpty()
            .WithMessage("Email not correct format");
        RuleFor(x => x.SalesmanDto.Position).MaximumLength(64).NotEmpty();
    }
}