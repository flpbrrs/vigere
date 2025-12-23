using System.Net;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereValidationException(List<string> errors) : VigereException(ResourceErrorMessages.VALIDATION_ERROR)
{
    private readonly List<string> _errors = errors;

    public override int StatusCode => (int) HttpStatusCode.BadRequest;

    public override List<string> GetErrorCodes()
    {
        return _errors;
    }
}
