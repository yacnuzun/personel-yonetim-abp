using System;
using System.Collections.Generic;
using System.Text;
using PersonelYonetim.Localization;
using Volo.Abp.Application.Services;

namespace PersonelYonetim;

/* Inherit your application services from this class.
 */
public abstract class PersonelYonetimAppService : ApplicationService
{
    protected PersonelYonetimAppService()
    {
        LocalizationResource = typeof(PersonelYonetimResource);
    }
}
