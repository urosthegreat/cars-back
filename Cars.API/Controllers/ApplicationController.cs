using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

public class ApplicationController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}