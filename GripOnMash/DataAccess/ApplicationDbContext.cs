﻿namespace GripOnMash.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public required DbSet<InternalUser> InternalUsers { get; init; }
        public required DbSet<InternalUserRole> InternalUserRoles { get; init; }
        public required DbSet<InternalUserAccess> InternalUserAccess { get; init; }
        public DbSet<Agenda> Agende { get; init; }
        public DbSet<Appuntamento> Appuntamenti { get; init; }
        public DbSet<NumeroPrenotazione> NumeroPrenotazioni { get; init; }
        public DbSet<Domanda> Domande { get; init; }
        public DbSet<Risposta> Risposte { get; init; }
        public DbSet<MedicoBaseAnagrafica> MedicoBaseAnagrafiche { get; init; }
        public DbSet<MailConfig> MailConfigs { get; init; }
        public DbSet<EsitoQuestionario> EsitoQuestionari { get; init; }
        public DbSet<RisposteEsitoQuestionario> RisposteEsitoQuestionari { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoles();
            modelBuilder.SeedInternalUsers();
            modelBuilder.SeedMediciBase();

            // Configurazione della struttura delle tabelle
            TableStructure.Configure(modelBuilder);

            // Configurazione delle relazioni tra le tabelle
            TableRelationship.Configure(modelBuilder);
        }


    }
}
