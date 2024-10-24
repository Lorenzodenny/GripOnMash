namespace GripOnMash.Models
{
    public class RisposteEsitoQuestionario
    {
        [Key]
        public int RisposteEsitoQuestionarioId { get; set; }
        public DateTime? DataQuestionario { get; set; }

        // Chiavi esterne a Domanda e Risposta
        public int DomandaId { get; set; }
        public Domanda Domanda { get; set; }

        public int RispostaId { get; set; }
        public Risposta Risposta { get; set; }

        // Chiave esterna a EsitoQuestionario
        public int EsitoQuestionarioId { get; set; }
        public EsitoQuestionario EsitoQuestionario { get; set; }
    }


}
