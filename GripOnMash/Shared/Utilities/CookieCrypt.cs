namespace GripOnMash.Shared.Utilities
{

    public class CookieCrypt
    {
        private readonly IDataProtector _protector;

        public CookieCrypt(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("CookieProtection");
        }

        public string Encrypt(string plainText)
        {
            return _protector.Protect(plainText);
        }

        public string Decrypt(string encryptedText)
        {
            return _protector.Unprotect(encryptedText);
        }
    }

}
