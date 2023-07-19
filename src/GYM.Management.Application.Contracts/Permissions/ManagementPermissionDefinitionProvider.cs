using GYM.Management.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GYM.Management.Permissions;

public class ManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ManagementPermissions.GroupName);
        //Define your own permissions here. Example:
        var exercisePermission = myGroup.AddPermission(ManagementPermissions.Exercise.Default, L("Permission:Exercise"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Create, L("Permission:Exercise.Create"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Edit, L("Permission:Exercise.Edit"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Delete, L("Permission:Exercise.Delete"));

        var categoryPermission = myGroup.AddPermission(ManagementPermissions.Category.Default, L("Permission:Category"));
        categoryPermission.AddChild(ManagementPermissions.Category.Create, L("Permission:Category.Create"));
        categoryPermission.AddChild(ManagementPermissions.Category.Edit, L("Permission:Category.Edit"));
        categoryPermission.AddChild(ManagementPermissions.Category.Delete, L("Permission:Category.Delete"));

		var trainerPermission = myGroup.AddPermission(ManagementPermissions.Trainer.Default, L("Permission:Trainer"));
        trainerPermission.AddChild(ManagementPermissions.Trainer.Create, L("Permission:Trainer.Create"));
        trainerPermission.AddChild(ManagementPermissions.Trainer.Edit, L("Permission:Trainer.Edit"));
        trainerPermission.AddChild(ManagementPermissions.Trainer.Delete, L("Permission:Trainer.Delete"));

        var productPermission = myGroup.AddPermission(ManagementPermissions.Product.Default, L("Permission:Product"));
        productPermission.AddChild(ManagementPermissions.Product.Create, L("Permission:Product.Create"));
        productPermission.AddChild(ManagementPermissions.Product.Edit, L("Permission:Product.Edit"));
        productPermission.AddChild(ManagementPermissions.Product.Delete, L("Permission:Product.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ManagementResource>(name);
    }
}
