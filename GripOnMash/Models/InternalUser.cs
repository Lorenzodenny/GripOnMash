using System.ComponentModel.DataAnnotations;

namespace GripOnMash.Models
{
    public class InternalUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Matricola { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }

        // Navigation Propertiy per gestire tutti i Role che daremo agli interni
        public ICollection<InternalUserRole> InternalUserRoles { get; set; }
        // Collezione di Agende create dall'Admin
        public ICollection<Agenda> Agende { get; set; }

    }
}
