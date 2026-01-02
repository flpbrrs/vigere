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
            var errors = result.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key.ToLower(),
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );

            throw new VigereValidationException(errors);
        }
    }

    public static bool IsValid<T>(this IValidator<T> validator, T instance)
    {
        var result = validator.Validate(instance);
        return result.IsValid;
    }
}
