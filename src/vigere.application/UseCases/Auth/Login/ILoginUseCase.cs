using vigere.application.Abstractions;
using vigere.comunication.Requests;
using vigere.comunication.Responses;

namespace vigere.application.UseCases.Auth.Login;

public interface ILoginUseCase : IUseCase<RequestUserLoginJson, ResponseAuthUserJson>{}
