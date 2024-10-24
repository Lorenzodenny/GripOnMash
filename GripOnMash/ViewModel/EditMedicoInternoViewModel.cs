namespace GripOnMash.Models.ViewModels
{
    public class EditMedicoInternoViewModel
    {
        public Guid Id { get; set; }
        public string Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public bool IsEnabled { get; set; }
    }
}
