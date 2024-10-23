namespace GripOnMash.SeedData
{
    public static class SeedMediciBaseExtension
    {
        public static void SeedMediciBase(this ModelBuilder modelBuilder)
        {
            var medicoBaseId1 = Guid.NewGuid().ToString();
            var medicoBaseId2 = Guid.NewGuid().ToString();

            // PasswordHasher per generare hash delle password
            var hasher = new PasswordHasher<ApplicationUser>();

            // Seed per i medici di base (ApplicationUser)
            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = medicoBaseId1,
                UserName = "medicoBase1_unico",  
                NormalizedUserName = "MEDICOBASE1_UNICO",  
                Email = "medicobase1@gmail.com",
                NormalizedEmail = "MEDICOBASE1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Udietta14!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Nome = "Marco",
                Cognome = "Silveri",
                IsDeleted = false,
                CodiceOtp = "654321"
            },
            new ApplicationUser
            {
                Id = medicoBaseId2,
                UserName = "medicoBase2_unico",  
                NormalizedUserName = "MEDICOBASE2_UNICO",  
                Email = "medicobase2@gmail.com",
                NormalizedEmail = "MEDICOBASE2@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Udietta14!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Nome = "Francesco",
                Cognome = "Gentile",
                IsDeleted = false,
                CodiceOtp = "123654"
            }
        );

            // Collegamento dei medici di base ai ruoli in Identity
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = medicoBaseId1,
                    RoleId = Ruoli.User  
                },
                new IdentityUserRole<string>
                {
                    UserId = medicoBaseId2,
                    RoleId = Ruoli.User
                }
            );

            
            modelBuilder.Entity<MedicoBaseAnagrafica>().HasData(
                new MedicoBaseAnagrafica
                {
                    MedicoBaseAnagraficaId = 1, 
                    IdentityId = medicoBaseId1,  
                    Nome = "Giuseppe",
                    Cognome = "Verdi",
                    Eta = 45,
                    NumeroTelefono = "123456789",
                    CodiceFiscale = "VRDGPP75E20H501Y",
                    Indirizzo = "Via Roma 1, Milano",
                    Specializzazione = "Cardiologia",
                    NumeroAlbo = "12345MI",
                    EmailPersonale = "giuseppe.verdi@gmail.com",
                    PartitaIVA = "12345678901"
                },
                new MedicoBaseAnagrafica
                {
                    MedicoBaseAnagraficaId = 2,
                    IdentityId = medicoBaseId2,
                    Nome = "Francesca",
                    Cognome = "Bianchi",
                    Eta = 38,
                    NumeroTelefono = "987654321",
                    CodiceFiscale = "BNCFNC82C15H501Z",
                    Indirizzo = "Via Torino 10, Torino",
                    Specializzazione = "Dermatologia",
                    NumeroAlbo = "67890TO",
                    EmailPersonale = "francesca.bianchi@gmail.com",
                    PartitaIVA = "98765432109"
                }
            );
        }
    }
}