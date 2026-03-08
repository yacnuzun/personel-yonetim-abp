using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonelYonetim.Data;
using Volo.Abp.DependencyInjection;

namespace PersonelYonetim.EntityFrameworkCore;

public class EntityFrameworkCorePersonelYonetimDbSchemaMigrator
    : IPersonelYonetimDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePersonelYonetimDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the PersonelYonetimDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PersonelYonetimDbContext>()
            .Database
            .MigrateAsync();
    }
}
