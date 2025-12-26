using Microsoft.AspNetCore.Diagnostics;
using vigere.exceptions.Resources;
using vigere.comunication.Responses;
using vigere.exceptions;

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
        return (
            exception.StatusCode,
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
