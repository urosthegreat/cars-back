namespace Cars.Application.Common.Dtos;

public record CarDto(string?  Id, string? Manufacturer, string? Model, DateTime? YearOfMake, double? Price);