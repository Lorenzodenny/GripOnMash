public static class SeedRoleExtension
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = Ruoli.Admin,  
                Name = nameof(Ruoli.Admin),
                NormalizedName = nameof(Ruoli.Admin).ToUpper()
            },
            new IdentityRole
            {
                Id = Ruoli.User,  
                Name = nameof(Ruoli.User),
                NormalizedName = nameof(Ruoli.User).ToUpper()
            }
        );
    }
}
