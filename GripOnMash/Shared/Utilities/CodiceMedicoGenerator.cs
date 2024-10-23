namespace GripOnMash.Shared.Utilities
{
    public static class CodiceMedicoGenerator
    {
        // Metodo statico per generare un codice medico univoco
        public static async Task<string> GenerateUniqueCodiceMedicoAsync(ApplicationDbContext context)
        {
            string codiceMedico;
            bool exists;

            // Continua a generare il codice finché non ne trovi uno univoco
            do
            {
                // Genera un codice medico di 4 caratteri
                codiceMedico = PasswordGenerator.Generate(4, 4, requireDigit: true, requireLowercase: false, requireNonAlphanumeric: false, requireUppercase: true);

                // Verifica se il codice esiste già nel database
                exists = await context.Users.AnyAsync(u => u.CodiceMedico == codiceMedico);

            } while (exists);

            return codiceMedico;
        }
    }
}
