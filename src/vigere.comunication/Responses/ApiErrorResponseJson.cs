using vigere.exceptions.Resources;

namespace vigere.comunication.Responses;

public class ApiErrorResponseJson
{
    public string? Message { get; }
    public object? ErrorCodes { get; }

    public ApiErrorResponseJson(string message, object? errors)
    {
        Message = message;
        ErrorCodes = errors;
    }

    public ApiErrorResponseJson(string message)
    {
        Message = message;
        ErrorCodes = new[] { ResourceErrorCodes.UNKNOW_ERROR };
    }
}
