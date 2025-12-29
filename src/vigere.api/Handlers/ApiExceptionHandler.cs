using Microsoft.AspNetCore.Diagnostics;
using vigere.comunication.Responses;
using vigere.exceptions.Bases;
using vigere.exceptions.Resources;

namespace vigere.api.Handlers;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var (statusCode, message) = exception switch
        {
            VigereException ex => HandleDomainException(ex),
            _ => HandleUnknowException(exception)
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(
            message,
            cancellationToken
        );

        return true;
    }

    private (int, ApiErrorResponseJson) HandleDomainException(VigereException exception)
    {
        var statusCode = exception.ErrorType switch
        {
            VigereErrorType.Validation => StatusCodes.Status400BadRequest,
            VigereErrorType.BusinessRule => StatusCodes.Status400BadRequest,
            VigereErrorType.ResourceNotFound => StatusCodes.Status404NotFound,
            VigereErrorType.Conflict => StatusCodes.Status409Conflict,
            VigereErrorType.Unauthorized => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        return (
            statusCode,
            new ApiErrorResponseJson(
                exception.Message,
                exception.GetErrorCodes()
            )
        );
    }

    private (int, ApiErrorResponseJson) HandleUnknowException(Exception exception)
    {
        return exception switch
        {
            _ => (
                StatusCodes.Status500InternalServerError,
                new ApiErrorResponseJson(ResourceErrorMessages.UNEXPECTED_ERROR)
            )
        };
    }
}
