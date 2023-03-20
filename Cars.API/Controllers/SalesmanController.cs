using Cars.Application.Command.Salesman;
using Cars.Application.Common.Dtos;
using Cars.Application.Query.Salesman;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SalesmanController : ApplicationController
{
    [HttpPost]
    public async Task<OkObjectResult> InsertSalesman(SalesmanDto salesmanDto)
        => Ok(await Mediator.Send(new CreateSalesmanCommand(salesmanDto)));

    [HttpGet]
    public async Task<OkObjectResult> ViewSalesman()
        => Ok(await Mediator.Send(new GetAllQuery()));

    [HttpPut]
    public async Task<OkObjectResult> UpdateSalesman(SalesmanDto salesmanDto)
        => Ok(await Mediator.Send(new UpdateSalesmanCommand(salesmanDto)));

    [HttpDelete]
    public async Task<OkObjectResult> DeleteSalesman(SalesmanDto salesmanDto)
        => Ok(await Mediator.Send(new DeleteSalesmanCommand(salesmanDto)));

    [HttpPut]
    public async Task<OkObjectResult> AddSoldCar(string soldCarId, string salesmanId)
        => Ok(await Mediator.Send(new AddSoldCarCommand(soldCarId, salesmanId)));

    [HttpPut]
    public async Task<OkObjectResult> RemoveSoldCar(string soldCarId, string salesmanId)
        => Ok(await Mediator.Send(new RemoveSoldCarCommand(soldCarId, salesmanId)));
    
    [HttpGet]
    public async Task<OkObjectResult> GetSoldCars(string salesmanId)
        => Ok(await Mediator.Send(new GetSoldCarsCommand(salesmanId)));
}