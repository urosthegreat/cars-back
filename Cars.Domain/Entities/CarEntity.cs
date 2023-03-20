using MongoDB.Entities;

namespace Cars.Domain.Entities;

[Collection("cars")]
public class CarEntity : Entity, ICreatedOn, IModifiedOn
{
    [Field("manufacturer")] public string? Manufacturer { get; set; }
    [Field("model")] public string? Model { get; set; }
    [Field("year_of_make")] public DateTime? YearOfMake { get; set; }
    [Field("price")] public double? Price { get; set; }
    [Field("sold_by_salesman")] public One<SalesmanEntity> SalesmanEntity { get; set; }
    [Field("created_on")] public DateTime CreatedOn { get; set; }
    [Field("modified_on")] public DateTime ModifiedOn { get; set; }
}