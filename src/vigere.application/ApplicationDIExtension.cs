using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using vigere.application.UseCases.Auth.Login;
using vigere.application.UseCases.Users.Register;

namespace vigere.application;

public static class ApplicationDIExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();

        services.AddValidatorsFromAssemblyContaining<RegisterUserUseCase>();

        return services;
    }
}
