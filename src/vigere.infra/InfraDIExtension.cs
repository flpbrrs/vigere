using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vigere.domain.Providers;
using vigere.domain.Repositories;
using vigere.domain.Repositories.Users;
using vigere.infra.Database;
using vigere.infra.Database.Repositories;
using vigere.infra.Security;

namespace vigere.infra;

public static class InfraDIExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VigereDbContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IWriteOnlyUsersRepository, UserRepository>();
        services.AddScoped<IReadOnlyUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IEncrypter, BcryptEncrypter>();

        return services;
    }
}
