using vigere.exceptions.Bases;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereValidationException(IDictionary<string, string[]> errors) : VigereException(ResourceErrorMessages.VALIDATION_ERROR)
{
    private readonly IDictionary<string, string[]> _errors = errors;

    public override VigereErrorType ErrorType => VigereErrorType.Validation;

    public override object GetErrorCodes()
    {
        return _errors;
    }
}
