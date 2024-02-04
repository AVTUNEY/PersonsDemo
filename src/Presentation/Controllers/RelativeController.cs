using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/relatives")]
public class RelativeController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public RelativeController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRelative([FromBody] RelativeForCreationDto relativeForCreation)
    {
        var dto = await _serviceManager.RelativeService.CreateAsync(relativeForCreation);

        return Ok(dto);
    }
    
    [HttpDelete("{personId}")]
    public async Task<IActionResult> DeletePerson(int personId, CancellationToken cancellationToken)
    {
        await _serviceManager.RelativeService.DeleteAsync(personId, cancellationToken);
        
        return NoContent();
    }
}