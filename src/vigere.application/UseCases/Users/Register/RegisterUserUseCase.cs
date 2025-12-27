using FluentValidation;
using vigere.application.Extensions;
using vigere.comunication.Requests;
using vigere.comunication.Responses;
using vigere.domain.Providers;
using vigere.domain.Repositories;
using vigere.domain.Repositories.Users;
using vigere.exceptions;
using vigere.exceptions.Resources;

namespace vigere.application.UseCases.Users.Register;

public class RegisterUserUseCase(
    IWriteOnlyUsersRepository _writeRepository,
    IReadOnlyUserRepository _readRepository,
    IUnitOfWork _UoW,
    IValidator<RequestRegisterUserJson> _validator,
    IEncrypter _encrypter,
    ITokenGenerator _tokenGenerator
) : IRegisterUserUseCase
{
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        _validator.ValidateAndThrowIfInvalid(request);
    
        if (await _readRepository.ExistsUserWithEmail(request.Email))
            throw new VigereDomainException(ResourceErrorCodes.USER_ALREADY_EXISTS);

        var encryptedPassword = _encrypter.Encrypt(request.Password);

        var user = request.ToEntityWithEncryptedPassword(encryptedPassword);

        await _writeRepository.Register(user);
        await _UoW.Commit();

        return new ResponseRegisterUserJson
        {
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}
