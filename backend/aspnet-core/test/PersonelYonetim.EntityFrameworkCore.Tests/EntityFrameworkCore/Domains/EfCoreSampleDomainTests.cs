using PersonelYonetim.Samples;
using Xunit;

namespace PersonelYonetim.EntityFrameworkCore.Domains;

[Collection(PersonelYonetimTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<PersonelYonetimEntityFrameworkCoreTestModule>
{

}
