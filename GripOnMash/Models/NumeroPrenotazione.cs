namespace GripOnMash.Models
{
    public class NumeroPrenotazione
    {
        [Key]
        public int NumeroPrenotazioneId { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public bool IsFull { get; set; }
    }
}
