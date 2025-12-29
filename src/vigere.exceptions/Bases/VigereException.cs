namespace vigere.exceptions.Bases;

public abstract class VigereException(string message) : SystemException(message)
{
    public abstract VigereErrorType ErrorType { get; }
    public abstract object GetErrorCodes();
}
