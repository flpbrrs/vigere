using vigere.application.Abstractions;
using vigere.comunication.Requests;

namespace vigere.application.UseCases.Users.Register;

public interface IRegisterUserUseCase: IUseCase<RequestRegisterUserJson, Empty> {}
