using FluentValidation;
using vigere.application.Abstractions;
using vigere.application.Extensions;
using vigere.comunication.Requests;
using vigere.domain.Repositories;
using vigere.domain.Repositories.Users;

namespace vigere.application.UseCases.Users.Register;

public class RegisterUserUseCase(
    IWriteOnlyUsersRepository _repository,
    IUnitOfWork _UoW,
    IValidator<RequestRegisterUserJson> _validator
) : IRegisterUserUseCase
{
    public Task<Empty> Execute(RequestRegisterUserJson request)
    {
        _validator.ValidateAndThrowIfInvalid(request);

        throw new NotImplementedException();
    }
}
