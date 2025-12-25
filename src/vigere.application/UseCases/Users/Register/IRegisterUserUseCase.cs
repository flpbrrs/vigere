using vigere.application.Abstractions;
using vigere.comunication.Requests;
using vigere.comunication.Responses;

namespace vigere.application.UseCases.Users.Register;

public interface IRegisterUserUseCase: IUseCase<RequestRegisterUserJson, ResponseRegisterUserJson> {}
