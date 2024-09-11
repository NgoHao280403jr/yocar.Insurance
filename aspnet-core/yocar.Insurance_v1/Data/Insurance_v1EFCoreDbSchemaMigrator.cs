using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace yocar.Insurance_v1.Data;

public class Insurance_v1EFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public Insurance_v1EFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Insurance_v1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Insurance_v1DbContext>()
            .Database
            .MigrateAsync();
    }
}
