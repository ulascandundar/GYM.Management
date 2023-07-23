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
        productPermission.AddChild(ManagementPermissions.Product.StockOrder, L("Permission:Product.StockOrder"));
        productPermission.AddChild(ManagementPermissions.Product.StockTaking, L("Permission:Product.StockTaking"));
        productPermission.AddChild(ManagementPermissions.Product.StockTakingHistory, L("Permission:Product.StockTakingHistory"));

        var walletPermission = myGroup.AddPermission(ManagementPermissions.Wallet.Default, L("Permission:Wallet"));
        walletPermission.AddChild(ManagementPermissions.Wallet.Edit, L("Permission:Wallet.Edit"));

        var memberPermission = myGroup.AddPermission(ManagementPermissions.Member.Default, L("Permission:Member"));
        memberPermission.AddChild(ManagementPermissions.Member.Create, L("Permission:Member.Create"));
        memberPermission.AddChild(ManagementPermissions.Member.Edit, L("Permission:Member.Edit"));
        memberPermission.AddChild(ManagementPermissions.Member.Delete, L("Permission:Member.Delete"));
        memberPermission.AddChild(ManagementPermissions.Member.AddProduct, L("Permission:Member.AddProduct"));
        memberPermission.AddChild(ManagementPermissions.Member.AddAppointment, L("Permission:Member.AddAppointment"));
        memberPermission.AddChild(ManagementPermissions.Member.History, L("Permission:Member.History"));
        memberPermission.AddChild(ManagementPermissions.Member.Pay, L("Permission:Member.Pay"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ManagementResource>(name);
    }
}
