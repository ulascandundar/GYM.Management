namespace GYM.Management.Permissions;

public static class ManagementPermissions
{
    public const string GroupName = "Management";

    //Add your own permission names. Example:
    public const string ExerciseGet = GroupName + ".ExerciseGet";

    public static class Exercise
    {
        public const string Default = GroupName + ".Exercise";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Category
    {
        public const string Default = GroupName + ".Category";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

	public static class Trainer
	{
		public const string Default = GroupName + ".Trainer";
		public const string Create = Default + ".Create";
		public const string Edit = Default + ".Edit";
		public const string Delete = Default + ".Delete";
	}

    public static class Product
    {
        public const string Default = GroupName + ".Product";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string StockOrder = Default + ".StockOrder";
        public const string StockTaking = Default + ".StockTaking";
        public const string StockTakingHistory = Default + ".StockTakingHistory";
		public const string StockOrderHistory = Default + ".StockOrderHistory";
        public const string StockLossCreate = Default + ".StockLossCreate";
        public const string StockLossHistory = Default + ".StockLossHistory";

    }
    public static class Wallet
    {
        public const string Default = GroupName + ".Wallet";
        public const string Edit = Default + ".Edit";
    }

    public static class Member
    {
        public const string Default = GroupName + ".Member";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string AddProduct = Default + ".AddProduct";
        public const string AddAppointment = Default + ".AddAppointment";
        public const string History = Default + ".History";
        public const string Pay = Default + ".Pay";
        public const string AppointmentTransaction = Default + ".AppointmentTransaction";
    }

    public static class Expense
    {
        public const string Default = GroupName + ".Expense";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Safe
    {
        public const string Default = GroupName + ".Safe";
    }

    public static class Graphic
    {
        public const string Default = GroupName + ".Graphic";
    }

    public static class Hangfire
    {
        public const string Default = GroupName + ".Hangfire";
    }

    public static class ExpenseType
    {
        public const string Default = GroupName + ".ExpenseType";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
