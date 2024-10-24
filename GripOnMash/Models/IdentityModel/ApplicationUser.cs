namespace GripOnMash.Models.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        // Campi custom per identity
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public bool IsDeleted { get; set; } = false; 
        public string CodiceOtp { get; set; }
        public string CodiceMedico { get; set; }

        // Proprietà di navigazione per MedicoBaseAnagrafica
        public MedicoBaseAnagrafica MedicoBaseAnagrafica { get; set; }

        // Collezione di appuntamenti associati all'utente
        public ICollection<Appuntamento> Appuntamenti { get; set; }
    }
}
