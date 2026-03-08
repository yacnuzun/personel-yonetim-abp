using PersonelYonetim.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PersonelYonetim.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PersonelYonetimController : AbpControllerBase
{
    protected PersonelYonetimController()
    {
        LocalizationResource = typeof(PersonelYonetimResource);
    }
}
