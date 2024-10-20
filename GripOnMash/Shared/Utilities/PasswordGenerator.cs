namespace GripOnMash.Shared.Utilities
{
    public static class PasswordGenerator
    {
        public static string GenerateRandomPassword(int length = 12)
        {
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*";

            Random random = new Random();

            // Assicura che ci sia almeno un carattere da ciascun set obbligatorio
            var passwordChars = new List<char>
        {
            lowerChars[random.Next(lowerChars.Length)],  // Almeno una lettera minuscola
            upperChars[random.Next(upperChars.Length)],  // Almeno una lettera maiuscola
            digits[random.Next(digits.Length)],          // Almeno un numero
            specialChars[random.Next(specialChars.Length)] // Almeno un carattere speciale
        };

            // Aggiungi caratteri casuali fino a raggiungere la lunghezza desiderata
            string allChars = lowerChars + upperChars + digits + specialChars;
            passwordChars.AddRange(Enumerable.Repeat(allChars, length - passwordChars.Count)
                .Select(s => s[random.Next(s.Length)]));

            // Mischia i caratteri per evitare che i primi quattro siano sempre nelle stesse posizioni
            return new string(passwordChars.OrderBy(c => random.Next()).ToArray());
        }
    }
}
