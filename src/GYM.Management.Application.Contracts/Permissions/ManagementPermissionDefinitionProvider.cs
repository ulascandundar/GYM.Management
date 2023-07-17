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
        myGroup.AddPermission(ManagementPermissions.ExerciseGet, L("Permission:ExerciseGet"));
        var exercisePermission = myGroup.AddPermission(ManagementPermissions.Exercise.Default, L("Permission:Exercise"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Create, L("Permission:Exercise.Create"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Edit, L("Permission:Exercise.Edit"));
        exercisePermission.AddChild(ManagementPermissions.Exercise.Delete, L("Permission:Exercise.Delete"));

        var categoryPermission = myGroup.AddPermission(ManagementPermissions.Category.Default, L("Permission:Category"));
        exercisePermission.AddChild(ManagementPermissions.Category.Create, L("Permission:Category.Create"));
        exercisePermission.AddChild(ManagementPermissions.Category.Edit, L("Permission:Category.Edit"));
        exercisePermission.AddChild(ManagementPermissions.Category.Delete, L("Permission:Category.Delete"));

		var trainerPermission = myGroup.AddPermission(ManagementPermissions.Trainer.Default, L("Permission:Trainer"));
		exercisePermission.AddChild(ManagementPermissions.Trainer.Create, L("Permission:Trainer.Create"));
		exercisePermission.AddChild(ManagementPermissions.Trainer.Edit, L("Permission:Trainer.Edit"));
		exercisePermission.AddChild(ManagementPermissions.Trainer.Delete, L("Permission:Trainer.Delete"));
	}

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ManagementResource>(name);
    }
}
