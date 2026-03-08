using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PersonelYonetim.Data;

/* This is used if database provider does't define
 * IPersonelYonetimDbSchemaMigrator implementation.
 */
public class NullPersonelYonetimDbSchemaMigrator : IPersonelYonetimDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
