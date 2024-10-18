namespace GripOnMash.Services
{
    public class LoginService
    {
        private readonly LdapConfig _config;

        public LoginService(LdapConfig config)
        {
            _config = config;
        }

        private const string DisplayNameAttribute = "DisplayName";
        private const string SamAccountNameAttribute = "SAMAccountName";

        public static async Task<bool> LoginLdap(string user, string pass)
        {
            try
            {
                await Task.CompletedTask;

                using var entry = new System.DirectoryServices.DirectoryEntry($"{LdapConfig.Server}:{LdapConfig.Port}",
                    LdapConfig.Domain + "\\" + user,
                    pass);

                using var searcher = new DirectorySearcher(entry);
                searcher.Filter = $"({SamAccountNameAttribute}={user})";
                searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                searcher.PropertiesToLoad.Add(SamAccountNameAttribute);

                var result = searcher.FindOne();

                if (result == null)
                    return false;

                var displayName = result.Properties[DisplayNameAttribute];
                var samAccountName = result.Properties[SamAccountNameAttribute];
                var displayNameOut = displayName is not { Count: > 0 } ? null : displayName[0].ToString();
                var userNameOut = samAccountName is not { Count: > 0 } ? null : samAccountName[0].ToString();

                return userNameOut is not null && displayNameOut is not null;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                if (e.Message.Contains("Nome utente o password non corretta.")
                   || e.Message.Contains("The user name or password is incorrect."))
                    return false;
                throw;
            }
        }
    }
}
