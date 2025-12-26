using System.Net;
using vigere.exceptions.Resources;

namespace vigere.exceptions;

public class VigereDomainException(string message) : VigereException(ResourceErrorMessages.DOMAIN_ERROR)
{
    public override int StatusCode => (int) HttpStatusCode.BadRequest;

    public override object GetErrorCodes()
    {
        return new List<string>() { message };
    }
}
