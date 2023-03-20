using Cars.Application.Command.Car;
using Cars.Application.Common.Dtos;
using Cars.Application.Query.Car;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CarController : ApplicationController
{
    [HttpPost]
    public async Task<OkObjectResult> InsertCar(CarDto carDto)
         => Ok(await Mediator.Send(new CreateCarCommand(carDto)));
    
    [HttpGet]
    public async Task<OkObjectResult> ViewCars()
        => Ok(await Mediator.Send(new GetAllQuery()));
}