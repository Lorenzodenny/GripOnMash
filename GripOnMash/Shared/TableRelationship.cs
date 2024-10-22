namespace GripOnMash.Shared
{
    public static class TableRelationship
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Relazione tra InternalUser (Admin) e Agenda
            modelBuilder.Entity<Agenda>(e =>
            {
                e.ToTable(TableName.Agenda);
                e.HasOne(a => a.InternalUser)
                    .WithMany(iu => iu.Agende)
                    .HasForeignKey(a => a.InternalUserId);  
            });

            // Relazione con Identiy ( User MedicoDiBase ) e Appuntamento
            modelBuilder.Entity<Appuntamento>(e =>
            {
                e.ToTable(TableName.Appuntamento);
                e.HasOne(a => a.IdentityUser)
                    .WithMany(iu => iu.Appuntamenti)
                    .HasForeignKey(a => a.IdentityId);  
            });

            // Relazione tra InternalUser e InternalUserRole 
            modelBuilder.Entity<InternalUserRole>(e =>
            {
                e.ToTable(TableName.InternalUserRole);

                e.HasKey(iur => new { iur.InternalUserId, iur.RoleId });  // Chiave composta da due chiave per unicità (tabella ponte)

                e.HasOne(iur => iur.InternalUser)
                    .WithMany(iu => iu.InternalUserRoles)
                    .HasForeignKey(iur => iur.InternalUserId)
                    .IsRequired();  

                e.HasOne(iur => iur.Role)
                    .WithMany()
                    .HasForeignKey(iur => iur.RoleId)
                    .IsRequired();  
            });

            modelBuilder.Entity<Domanda>(e =>
            {
                e.ToTable(TableName.Domanda);
                e.HasMany(d => d.Risposte)
                    .WithOne(r => r.Domanda)
                    .HasForeignKey(r => r.DomandaId);
            });


            // Relazione tra MedicoBaseAnagrafica e ApplicationUser ( Ereditata da Identity)
            modelBuilder.Entity<MedicoBaseAnagrafica>(e =>
            {
                e.ToTable(TableName.MedicoBaseAnagrafica);

                // Configurazione della relazione con ApplicationUser
                e.HasOne(m => m.IdentityUser)
                      .WithOne(u => u.MedicoBaseAnagrafica)
                      .HasForeignKey<MedicoBaseAnagrafica>(m => m.IdentityId)
                      .IsRequired();
            });

            // Configurazione di EsitoQuestionario
            modelBuilder.Entity<EsitoQuestionario>(e =>
            {
                e.ToTable(TableName.EsitoQuestionario);

                e.HasKey(eq => eq.EsitoQuestionarioId);

                // Relazione con ApplicationUser (MedicoBase)
                e.HasOne(eq => eq.MedicoBase)
                    .WithMany()
                    .HasForeignKey(eq => eq.MedicoBaseId)
                    .IsRequired();

                // Relazione con RisposteEsitoQuestionario
                e.HasMany(eq => eq.RisposteEsitoQuestionario)
                    .WithOne(re => re.EsitoQuestionario)
                    .HasForeignKey(re => re.EsitoQuestionarioId)
                    .IsRequired();
            });

            // Configurazione di RisposteEsitoQuestionario
            modelBuilder.Entity<RisposteEsitoQuestionario>(e =>
            {
                e.ToTable(TableName.RisposteEsitoQuestionario);

                e.HasKey(re => re.RisposteEsitoQuestionarioId);

                // Relazione con Domanda
                e.HasOne(re => re.Domanda)
                    .WithMany()
                    .HasForeignKey(re => re.DomandaId)
                    .IsRequired();

                // Relazione con Risposta
                e.HasOne(re => re.Risposta)
                    .WithMany()
                    .HasForeignKey(re => re.RispostaId)
                    .IsRequired();

                // Relazione con EsitoQuestionario
                e.HasOne(re => re.EsitoQuestionario)
                    .WithMany(eq => eq.RisposteEsitoQuestionario)
                    .HasForeignKey(re => re.EsitoQuestionarioId)
                     .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });

        }

    }
}
