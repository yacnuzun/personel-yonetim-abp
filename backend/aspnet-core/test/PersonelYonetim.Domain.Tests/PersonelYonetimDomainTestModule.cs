using Volo.Abp.Modularity;

namespace PersonelYonetim;

[DependsOn(
    typeof(PersonelYonetimDomainModule),
    typeof(PersonelYonetimTestBaseModule)
)]
public class PersonelYonetimDomainTestModule : AbpModule
{

}
