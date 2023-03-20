using MongoDB.Entities;

namespace Cars.Domain.Entities;

public class SalesmanEntity : Entity, ICreatedOn, IModifiedOn
{
    [Field("first_name")] public string? FirstName { get; set; }
    [Field("last_name")] public string? LastName { get; set; }
    [Field("email")] public string? Email { get; set; }
    [Field("position")] public string? Position { get; set; }
    [Field("cars_sold")] public Many<CarEntity> CarEntities { get; set; }
    [Field("created_on")] public DateTime CreatedOn { get; set; }
    [Field("modified_on")] public DateTime ModifiedOn { get; set; }

    public SalesmanEntity()
    {
        this.InitOneToMany(() => CarEntities);
    }
}