namespace GripOnMash.Models
{
    public class Domanda
    {
        [Key]
        public int DomandaId { get; set; }
        public string DomandaTesto { get; set; }
        public string DomandaTooltip { get; set; }
        public bool DomandaInclusione { get; set; }

        // Risposte associate a questa domanda
        public ICollection<Risposta> Risposte { get; set; }
    }

}
