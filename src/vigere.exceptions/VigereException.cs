namespace vigere.exceptions;

public abstract class VigereException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrorCodes();
}
