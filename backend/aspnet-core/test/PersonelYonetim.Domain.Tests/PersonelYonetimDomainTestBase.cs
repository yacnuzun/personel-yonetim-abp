using Volo.Abp.Modularity;

namespace PersonelYonetim;

/* Inherit from this class for your domain layer tests. */
public abstract class PersonelYonetimDomainTestBase<TStartupModule> : PersonelYonetimTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
