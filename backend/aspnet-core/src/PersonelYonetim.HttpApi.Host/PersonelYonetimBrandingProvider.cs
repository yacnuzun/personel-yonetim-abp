using Microsoft.Extensions.Localization;
using PersonelYonetim.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PersonelYonetim;

[Dependency(ReplaceServices = true)]
public class PersonelYonetimBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PersonelYonetimResource> _localizer;

    public PersonelYonetimBrandingProvider(IStringLocalizer<PersonelYonetimResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
