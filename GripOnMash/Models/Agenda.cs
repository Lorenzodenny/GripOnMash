using GripOnMash.Enums;

namespace GripOnMash.Models
{
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }
        public GiornoSettimana GiornoSettimana { get; set; }
        public DateTime ValidoDalGiorno { get; set; }
        public DateTime ValidoFinoAlGiorno { get; set; }
        public TimeSpan OraInizio { get; set; }
        public int NumeroMassimoPazienti { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Utente Interno ( Admin )
        public Guid InternalUserId { get; set; }  
        public InternalUser? InternalUser { get; set; }
    }
}
