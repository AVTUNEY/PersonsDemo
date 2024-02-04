using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/person-connection")]
public class PersonConnectionController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PersonConnectionController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersonConnection([FromBody] CreatePersonConnectionDto createConnection)
    {
        var dto = await _serviceManager.PersonConnectionService.CreateAsync(createConnection);

        return Ok(dto);
    }
    
    [HttpDelete("{personId}")]
    public async Task<IActionResult> DeletePersonConnection(int personId, CancellationToken cancellationToken)
    {
        await _serviceManager.PersonConnectionService.DeleteAsync(personId, cancellationToken);
        
        return NoContent();
    }
}