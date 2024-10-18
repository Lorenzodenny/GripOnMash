namespace GripOnMash.Shared.Authentication
{
    public class LdapConfig
    {
        internal static string Domain { get; } = "rmucsc";
        internal static string Server { get; } = "LDAP://rmucsc.rm.unicatt.it";
        internal static string SearchBase { get; } = "DC=rmucsc,DC=it";
        internal static string Schema { get; } = "Active Directory";
        internal static bool IsRecursiveGroupMembership { get; } = true;
        internal static int Port { get; } = 389;
        internal static bool IsSsl { get; } = true;
        internal static bool IsNoCertificateCheck { get; } = true;

    }
}
