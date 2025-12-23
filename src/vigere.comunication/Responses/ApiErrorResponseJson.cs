using vigere.exceptions.Resources;

namespace vigere.comunication.Responses;

public class ApiErrorResponseJson(string? message, List<string>? codes) 
{
    public string? Message { get; } = message;
    public List<string>? ErrorCodes { get; } = codes;

    public ApiErrorResponseJson(string message) : this(message, [ResourceErrorCodes.UNKNOW_ERROR]) {}
}
