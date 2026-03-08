using PersonelYonetim.Samples;
using Xunit;

namespace PersonelYonetim.EntityFrameworkCore.Applications;

[Collection(PersonelYonetimTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<PersonelYonetimEntityFrameworkCoreTestModule>
{

}
