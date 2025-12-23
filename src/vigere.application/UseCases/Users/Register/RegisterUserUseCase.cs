using vigere.application.Abstractions;
using vigere.comunication.Requests;
using vigere.domain.Repositories;
using vigere.domain.Repositories.Users;

namespace vigere.application.UseCases.Users.Register;

public class RegisterUserUseCase(
    IWriteOnlyUsersRepository _repository,
    IUnitOfWork _UoW
) : IRegisterUserUseCase
{
    public Task<Empty> Execute(RequestRegisterUserJson request)
    {
        throw new NotImplementedException();
    }
}
