using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[ValidateModel]
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

    [HttpGet("search")]
    public async Task<IActionResult> QuickSearch(string searchTerm, int pageNumber = 1, int pageSize = 10)
    {
        var searchResults = await _serviceManager.PersonService.SearchAndPaginate(searchTerm, pageNumber, pageSize);

        return Ok(searchResults);
    }

    [HttpGet("detailedSearch")]
    public async Task<IActionResult> DetailedSearch(string firstName, string lastName, string personalNumber,
        int pageNumber = 1, int pageSize = 10)
    {
        var result =
            await _serviceManager.PersonService.DetailedSearchAndPaginate(firstName, lastName, personalNumber,
                pageNumber, pageSize);

        return Ok(result);
    }

    [HttpGet("{targetPersonId}/{connectionType}")]
    public IActionResult GetConnectionReport(int targetPersonId, ConnectionType connectionType)
    {
        var result = _serviceManager.PersonService.GetConnectionReport(targetPersonId, connectionType);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto createPersonDto,
        CancellationToken cancellationToken)
    {
        var result = await _serviceManager.PersonService.CreateAsync(createPersonDto, cancellationToken);

        return CreatedAtAction(nameof(GetPersonById), new { personId = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson(int personId, [FromBody] UpdatePersonDto? personForUpdateDto,
        CancellationToken cancellationToken)
    {
        await _serviceManager.PersonService.UpdateAsync(personId, personForUpdateDto, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{personId}")]
    public async Task<IActionResult> DeletePerson(int personId, CancellationToken cancellationToken)
    {
        await _serviceManager.PersonService.DeleteAsync(personId, cancellationToken);

        return NoContent();
    }

    [HttpPost("photo/{personId}")]
    public async Task<IActionResult> UploadPhoto(int personId, [FromForm] UploadPersonPhoto photo,
        CancellationToken cancellationToken)
    {
        await _serviceManager.PersonService.UploadPhoto(personId, photo, cancellationToken);
        return Ok();
    }
}