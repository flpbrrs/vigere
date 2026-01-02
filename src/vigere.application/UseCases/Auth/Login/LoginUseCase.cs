using FluentValidation;
using vigere.application.Extensions;
using vigere.comunication.Requests;
using vigere.comunication.Responses;
using vigere.domain.Providers;
using vigere.domain.Repositories.Users;
using vigere.exceptions;

namespace vigere.application.UseCases.Auth.Login;

public class LoginUseCase(
    IReadOnlyUserRepository _readUserRepository,
    IEncrypter _passwordHasher,
    ITokenGenerator _tokenGenerator,
    IValidator<RequestUserLoginJson> _validator
) : ILoginUseCase
{
    private const string DUMMY_HASH = "$2a$11$M9.j3.p.X5Q.p.X5Q.p.X5Q.p.X5Q.p.X5Q.p.X5Q.p.X5Q.p.X5";
    public async Task<ResponseAuthUserJson> Execute(RequestUserLoginJson request)
    {
        if (!_validator.IsValid<RequestUserLoginJson>(request))
            throw new VigereInvalidCredentialsException();

        var user = await _readUserRepository.FindByEmail(request.Email);

        var passwordToVerify = user?.Password ?? DUMMY_HASH;

        var passwordMatches = _passwordHasher.Verify(passwordToVerify, request.Password);

        if (user is null || !passwordMatches)
            throw new VigereInvalidCredentialsException();

        return new ResponseAuthUserJson
        {
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}
