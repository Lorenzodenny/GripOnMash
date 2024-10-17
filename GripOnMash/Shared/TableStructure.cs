namespace GripOnMash.Shared
{
    public static class TableStructure
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configurazione di InternalUser
            modelBuilder.Entity<InternalUser>(e =>
            {
                e.ToTable(TableName.InternalUser);
                e.Property(iu => iu.Matricola)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(iu => iu.Cognome)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(iu => iu.Nome)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });

            // Configurazione di NumeroPrenotazione
            modelBuilder.Entity<NumeroPrenotazione>(e =>
            {
                e.ToTable(TableName.NumeroPrenotazione);
                e.Property(np => np.MinRange)
                    .IsRequired();
                e.Property(np => np.MaxRange)
                    .IsRequired();
                e.Property(np => np.IsFull)
                    .IsRequired();
            });

            // Configurazione di Appuntamento
            modelBuilder.Entity<Appuntamento>(e =>
            {
                e.ToTable(TableName.Appuntamento);
                e.Property(a => a.DataAppuntamento)
                    .IsRequired();
                e.Property(a => a.CodiceGenerato)
                    .IsRequired();
            });

            // Configurazione di Agenda
            modelBuilder.Entity<Agenda>(e =>
            {
                e.ToTable(TableName.Agenda);
                e.Property(a => a.GiornoSettimana)
                    .IsRequired()
                    .HasMaxLength(20);
                e.Property(a => a.ValidoDalGiorno)
                    .IsRequired();
                e.Property(a => a.ValidoFinoAlGiorno)
                    .IsRequired();
                e.Property(a => a.OraInizio)
                    .IsRequired();
                e.Property(a => a.NumeroMassimoPazienti)
                    .IsRequired();
            });

            // Configurazione di MedicoBaseAnagrafica
            modelBuilder.Entity<MedicoBaseAnagrafica>(e =>
            {
                e.ToTable(TableName.MedicoBaseAnagrafica);
                e.Property(m => m.Nome)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(m => m.Cognome)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(m => m.Eta)
                    .IsRequired();
                e.Property(m => m.NumeroTelefono) 
                    .IsUnicode(false)
                    .HasMaxLength(20);  
                e.Property(m => m.CodiceFiscale)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(16);
                e.Property(m => m.Indirizzo)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(200);
                e.Property(m => m.Specializzazione)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(m => m.NumeroAlbo)
                    .IsUnicode(false)
                    .HasMaxLength(50);
                e.Property(m => m.EmailPersonale)
                    .IsUnicode(false)
                    .HasMaxLength(100);
                e.Property(m => m.PartitaIVA)
                    .IsUnicode(false)
                    .HasMaxLength(11);
            });

            // Configurazione di Domanda
            modelBuilder.Entity<Domanda>(e =>
            {
                e.ToTable(TableName.Domanda);
                e.Property(d => d.DomandaTesto)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            // Configurazione di Risposta
            modelBuilder.Entity<Risposta>(e =>
            {
                e.ToTable(TableName.Risposta);
                e.Property(r => r.RispostaTesto)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(500);
                e.Property(r => r.IsCorretta)
                    .IsRequired();
            });

        }
    }
}
