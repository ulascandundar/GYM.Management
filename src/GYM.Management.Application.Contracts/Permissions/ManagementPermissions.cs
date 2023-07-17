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
}
