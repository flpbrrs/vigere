namespace vigere.application.Abstractions;

public interface IUseCase<TRequest, TResponse>
{
    Task<TResponse> Execute(TRequest request);
}

public readonly struct Empty { public static readonly Empty Value = default; }
