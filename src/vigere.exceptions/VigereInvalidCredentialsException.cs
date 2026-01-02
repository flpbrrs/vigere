using vigere.exceptions.Bases;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereInvalidCredentialsException() : VigereException(ResourceErrorMessages.INVALID_CREDENTIALS)
{
    public override VigereErrorType ErrorType => VigereErrorType.Unauthorized;

    public override object GetErrorCodes() => new List<string> { "invalid-credentials" };
}
