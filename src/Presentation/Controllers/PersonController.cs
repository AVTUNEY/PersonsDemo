using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonForCreationDto personForCreationDto)
    {
        var createdPersonDto = await _serviceManager.PersonService.CreateAsync(personForCreationDto);
        return CreatedAtAction(nameof(GetPersonById), new { personId = createdPersonDto.Id }, createdPersonDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson(int personId, [FromBody] PersonForUpdateDto personForUpdateDto,
        CancellationToken cancellationToken)
    {
        await _serviceManager.PersonService.UpdateAsync(personId, personForUpdateDto, cancellationToken);
        return NoContent();
    }
}