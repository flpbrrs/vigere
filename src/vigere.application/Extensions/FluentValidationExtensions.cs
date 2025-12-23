using FluentValidation;
using vigere.exceptions;

namespace vigere.application.Extensions;

public static class FluentValidationExtensions
{
    public static void ValidateAndThrowIfInvalid<T>(this IValidator<T> validator, T instance)
    {
        var result = validator.Validate(instance);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new VigereValidationException(errors);
        }
    }
}
