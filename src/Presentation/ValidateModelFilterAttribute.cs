namespace Presentation;

public class ValidationResultModel
{
    public string Status { get; }
    public List<ValidationError> Errors { get; }

    public ValidationResultModel(ModelStateDictionary modelState)
    {
        Status = "400";
        Errors = modelState.Keys
            .SelectMany(key => modelState[key]?.Errors.Select(x => new ValidationError(key, x.ErrorMessage)) ?? Array.Empty<ValidationError>())
            .ToList();
    }
}
public class ValidationError
{ 
    public string? Field { get; }

    public string Message { get; }

    public ValidationError(string? field, string message)
    {
        Field = field != string.Empty ? field : null;
        Message = message;
    }
}

public class ValidationFailedResult : ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState)
        : base(new ValidationResultModel(modelState))
    {
        StatusCode = StatusCodes.Status400BadRequest;
    }
}

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new ValidationFailedResult(context.ModelState);
        }
    }
}