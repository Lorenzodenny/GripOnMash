namespace GripOnMash.Models
{
    public class Appuntamento
    {
        [Key]
        public int AppuntamentoId { get; set; }
        public int CodiceGenerato { get; set; }
        public DateTime DataAppuntamento { get; set; }


        // Relazione con IdentityUser (Medico di Base)
        public string IdentityId { get; set; }
        public ApplicationUser IdentityUser { get; set; } // ApplicationUser == Identity
    }
}
