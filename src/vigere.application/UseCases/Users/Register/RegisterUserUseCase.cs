using FluentValidation;
using vigere.application.Extensions;
using vigere.comunication.Requests;
using vigere.comunication.Responses;
using vigere.domain.Repositories;
using vigere.domain.Repositories.Users;

namespace vigere.application.UseCases.Users.Register;

public class RegisterUserUseCase(
    IWriteOnlyUsersRepository _repository,
    IUnitOfWork _UoW,
    IValidator<RequestRegisterUserJson> _validator
) : IRegisterUserUseCase
{
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        _validator.ValidateAndThrowIfInvalid(request);

        var user = request.ToEntity();

        await _repository.Register(user);
        await _UoW.Commit();

        return user.ToRegisterResponse();
    }
}
