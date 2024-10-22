namespace GripOnMash.ViewModel
{
    public class PushEsitoQuestionarioViewModel
    {
        public int MedicoBaseId { get; set; }
        public List<RispostaSelezionataViewModel> RisposteSelezionate { get; set; }
        public bool PazienteIdoneo { get; set; } 
    }
}
