using PersonelYonetim.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PersonelYonetim.Permissions;

public class PersonelYonetimPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PersonelYonetimPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PersonelYonetimPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PersonelYonetimResource>(name);
    }
}
