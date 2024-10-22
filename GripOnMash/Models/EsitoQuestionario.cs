namespace GripOnMash.Models
{
    public class EsitoQuestionario
    {
        [Key]
        public int EsitoQuestionarioId { get; set; }

        // Riferimento al medico (ApplicationUser)
        public string MedicoBaseId { get; set; }
        public ApplicationUser MedicoBase { get; set; }  

        public bool PazienteIdoneo { get; set; }  

        // Collezione delle risposte collegate all'esito
        public ICollection<RisposteEsitoQuestionario> RisposteEsitoQuestionario { get; set; }
    }


}
