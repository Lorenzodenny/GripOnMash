namespace GripOnMash.Models
{
    public class InternalUserAccess
    {
        public int Id { get; set; }
        public string Matricola { get; private set; } = string.Empty;
        public DateTime Accesso { get; private set; }
        public DateTime? Uscita { get; set; }
        public DateTime ScadenzaToken { get; set; }
        public string? RefreshToken { get; set; } = string.Empty;

        public InternalUserAccess(int id, string matricola, DateTime accesso, DateTime? uscita, DateTime scadenzaToken, string? refreshToken)
        {
            Id = id;
            Matricola = matricola;
            Accesso = accesso;
            Uscita = uscita;
            ScadenzaToken = scadenzaToken;
            RefreshToken = refreshToken;
        }
    }
}
