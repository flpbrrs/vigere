using System.Net;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereValidationException(IDictionary<string, string[]> errors) : VigereException(ResourceErrorMessages.VALIDATION_ERROR)
{
    private readonly IDictionary<string, string[]> _errors = errors;

    public override int StatusCode => (int) HttpStatusCode.BadRequest;

    public override object GetErrorCodes()
    {
        return _errors;
    }
}
