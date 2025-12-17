using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using vigere.infra.Database;

namespace vigere.infra.Migrations;

public static class DbMigrationExtension
{
    public static async Task ApplyMigrationsAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<VigereDbContext>();

        try
        {
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}