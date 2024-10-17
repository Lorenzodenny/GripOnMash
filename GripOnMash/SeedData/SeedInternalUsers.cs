namespace GripOnMash.SeedData
{
    public static class SeedInternalUsersExtension
    {
        public static void SeedInternalUsers(this ModelBuilder modelBuilder)
        {
            // Genera GUID per gli InternalUser (Admin)
            var adminId1 = Guid.NewGuid();
            var adminId2 = Guid.NewGuid();
            var adminId3 = Guid.NewGuid();

            // Seed per gli utenti interni (admin)
            modelBuilder.Entity<InternalUser>().HasData(
                new InternalUser
                {
                    Id = adminId1,
                    Matricola = "sb004193",
                    Cognome = "Silveri",
                    Nome = "Marco",
                    IsEnabled = true
                },
                new InternalUser
                {
                    Id = adminId2,
                    Matricola = "00665539",
                    Cognome = "Picchi",
                    Nome = "Daniele",
                    IsEnabled = true
                },
                new InternalUser
                {
                    Id = adminId3,
                    Matricola = "sb004194",
                    Cognome = "Rossi",
                    Nome = "Mario",
                    IsEnabled = true
                }
            );

            // Collegamento degli admin ai ruoli in Identity
            modelBuilder.Entity<InternalUserRole>().HasData(
                new InternalUserRole
                {
                    InternalUserId = adminId1,  
                    RoleId = Ruoli.Admin        
                },
                new InternalUserRole
                {
                    InternalUserId = adminId2,  
                    RoleId = Ruoli.Admin
                },
                new InternalUserRole
                {
                    InternalUserId = adminId3,  
                    RoleId = Ruoli.Admin
                }
            );
        }
    }
}
