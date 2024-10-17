using GripOnMash.Models;
using Microsoft.EntityFrameworkCore;
using GripOnMash.Models.IdentityModel;

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
        }

    }
}
