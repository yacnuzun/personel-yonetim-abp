using Volo.Abp.Modularity;

namespace PersonelYonetim;

public abstract class PersonelYonetimApplicationTestBase<TStartupModule> : PersonelYonetimTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
