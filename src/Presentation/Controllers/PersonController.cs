using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/persons")]
public class PersonController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PersonController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet("{personId}")]
    public async Task<IActionResult> GetPersonById(int personId, CancellationToken cancellationToken)
    {
        var person = await _serviceManager.PersonService.GetByIdAsync(personId, cancellationToken);
        return Ok(person);
    }
}