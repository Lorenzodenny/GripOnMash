namespace GripOnMash.Models.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        // Proprietà di navigazione per MedicoBaseAnagrafica
        public MedicoBaseAnagrafica MedicoBaseAnagrafica { get; set; }

        // Collezione di appuntamenti associati all'utente
        public ICollection<Appuntamento> Appuntamenti { get; set; }
    }
}
