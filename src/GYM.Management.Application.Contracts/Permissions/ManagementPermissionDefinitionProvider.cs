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
		productPermission.AddChild(ManagementPermissions.Product.StockOrderHistory, L("Permission:Product.StockOrderHistory"));
        productPermission.AddChild(ManagementPermissions.Product.StockLossCreate, L("Permission:Product.StockLossCreate"));
        productPermission.AddChild(ManagementPermissions.Product.StockLossHistory, L("Permission:Product.StockLossHistory"));


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
        memberPermission.AddChild(ManagementPermissions.Member.AppointmentTransaction, L("Permission:Member.AppointmentTransaction"));

        var expensePermission = myGroup.AddPermission(ManagementPermissions.Expense.Default, L("Permission:Expense"));
        expensePermission.AddChild(ManagementPermissions.Expense.Create, L("Permission:Expense.Create"));
        expensePermission.AddChild(ManagementPermissions.Expense.Edit, L("Permission:Expense.Edit"));
        expensePermission.AddChild(ManagementPermissions.Expense.Delete, L("Permission:Expense.Delete"));

        var safePermission = myGroup.AddPermission(ManagementPermissions.Safe.Default, L("Permission:Safe"));

        var graphicPermission = myGroup.AddPermission(ManagementPermissions.Graphic.Default, L("Permission:Graphic"));

        var hangfirePermission = myGroup.AddPermission(ManagementPermissions.Hangfire.Default, L("Permission:Hangfire"));

        var expenseTypePermissiom = myGroup.AddPermission(ManagementPermissions.ExpenseType.Default, L("Permission:ExpenseType"));
        expenseTypePermissiom.AddChild(ManagementPermissions.ExpenseType.Create, L("Permission:ExpenseType.Create"));
        expenseTypePermissiom.AddChild(ManagementPermissions.ExpenseType.Edit, L("Permission:ExpenseType.Edit"));
        expenseTypePermissiom.AddChild(ManagementPermissions.ExpenseType.Delete, L("Permission:ExpenseType.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ManagementResource>(name);
    }
}
