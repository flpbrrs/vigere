using vigere.exceptions.Bases;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereDomainException(string message) : VigereException(ResourceErrorMessages.DOMAIN_ERROR)
{
    public override VigereErrorType ErrorType => VigereErrorType.BusinessRule;

    public override object GetErrorCodes()
    {
        return new List<string>() { message };
    }
}
