using Volo.Abp.Modularity;

namespace PersonelYonetim;

[DependsOn(
    typeof(PersonelYonetimApplicationModule),
    typeof(PersonelYonetimDomainTestModule)
)]
public class PersonelYonetimApplicationTestModule : AbpModule
{

}
