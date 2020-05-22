namespace Domain.App.Enums
{
    public class AppRoles
    {
        public const string User = "user";
        public const string Administrator = "admin";
        public static readonly string[] AllRoles = new []{User, Administrator};
    }
}