using FluentValidation;
using vigere.application.Extensions.Validators;
using vigere.comunication.Requests;
using vigere.exceptions.Resources;

namespace vigere.application.UseCases.Users;

public class UserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ResourceErrorCodes.EMAIL_REQUIRED)
            .EmailAddress().WithMessage(ResourceErrorCodes.EMAIL_INVALID);
        RuleFor(x => x.Password).MustBeValidPassword();
    }
}
