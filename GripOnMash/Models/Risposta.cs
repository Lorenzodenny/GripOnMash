namespace GripOnMash.Models
{
    public class Risposta
    {
        [Key]
        public int RispostaId { get; set; }
        public string RispostaTesto { get; set; }
        public bool IsCorretta { get; set; }

        // Chiave esterna per la domanda
        public int DomandaId { get; set; }
        public Domanda Domanda { get; set; }
    }

}
