using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GripOnMash.Models
{
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }
        public string GiornoSettimana { get; set; } = string.Empty;
        public DateTime ValidoDalGiorno { get; set; }
        public DateTime ValidoFinoAlGiorno { get; set; }
        public TimeSpan OraInizio { get; set; }
        public int NumeroMassimoPazienti { get; set; }

        // Utente Interno ( Admin )
        public Guid InternalUserId { get; set; }  
        public InternalUser InternalUser { get; set; }
    }
}
