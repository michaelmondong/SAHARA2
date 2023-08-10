namespace SAHARA2.Helpers
{
    internal class UserSession
    {
        public static string Username { get; private set; }
        public static string Role { get; private set; }

        public static bool IsLoggedIn { get; private set; }

        public static void SetUser(string username, string role)
        {
            Username = username;
            Role = role;
            IsLoggedIn = true;
        }

        public static void ClearUser()
        {
            Username = null;
            Role = null;
            IsLoggedIn = false;
        }

        internal static void SetToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
