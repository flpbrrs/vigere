using FluentValidation;
using vigere.exceptions.Resources;

namespace vigere.application.Common.Validators;

public static class PasswordValidatorExtension
{
    public static IRuleBuilderOptions<T, string> MustBeValidPassword<T>(
        this IRuleBuilder<T, string> ruleBuilder
    )
    {
        return ruleBuilder
            .NotEmpty().WithMessage(ResourceErrorCodes.PASSWORD_REQUIRED)
            .MinimumLength(6).WithMessage(ResourceErrorCodes.PASSWORD_INVALID_SIZE)
            .Matches(@"[A-Z]").WithMessage(ResourceErrorCodes.PASSWORD_MUST_CONTAIN_UPPERCASE)
            .Matches(@"[a-z]").WithMessage(ResourceErrorCodes.PASSWORD_MUST_CONTAIN_LOWERCASE)
            .Matches(@"[0-9]").WithMessage(ResourceErrorCodes.PASSWORD_MUST_CONTAIN_NUMBER)
            .Matches(@"[^a-zA-Z0-9]").WithMessage(ResourceErrorCodes.PASSWORD_MUST_CONTAIN_SPECIAL_CHAR);
    }
}
