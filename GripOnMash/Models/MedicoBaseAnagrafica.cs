using GripOnMash.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GripOnMash.Models
{
    public class MedicoBaseAnagrafica
    {
        [Key]
        public int MedicoBaseAnagraficaId { get; set; }
        public string IdentityId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }
        public string? NumeroTelefono { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string Specializzazione { get; set; }
        public string NumeroAlbo { get; set; }
        public string EmailPersonale { get; set; }
        public string PartitaIVA { get; set; }

        // Navigation Property con Identity
        public ApplicationUser IdentityUser { get; set; }
    }

}
