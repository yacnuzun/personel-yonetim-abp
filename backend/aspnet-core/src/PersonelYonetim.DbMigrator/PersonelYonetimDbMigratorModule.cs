using PersonelYonetim.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace PersonelYonetim.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PersonelYonetimEntityFrameworkCoreModule),
    typeof(PersonelYonetimApplicationContractsModule)
    )]
public class PersonelYonetimDbMigratorModule : AbpModule
{
}
