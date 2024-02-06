using Microsoft.AspNetCore.Http;

namespace Shared.DTOs.Persons;

public class UploadPersonPhoto
{
    [Required(ErrorMessage = "RequiredErrorMessage")]
    public IFormFile File { get; set; }
    public string Name { get; set; }
}