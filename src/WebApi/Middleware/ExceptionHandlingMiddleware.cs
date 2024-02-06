namespace WebApi.Middleware;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, IStringLocalizer<SharedResource> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = StatusCodes.Status500InternalServerError;
        var errorMessage = _localizer["DefaultErrorMessage"];

        if (exception is PersonNotFoundException notFoundException)
        {
            statusCode = StatusCodes.Status404NotFound;
            errorMessage = _localizer["PersonNotFoundErrorMessage", notFoundException.PersonId];
        }
       
        context.Response.StatusCode = statusCode;

        var response = new
        {
            Error = errorMessage.Value
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}