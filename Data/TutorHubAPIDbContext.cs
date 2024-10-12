using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutorHubAPI.Models.Domain;

namespace TutorHubAPI.Data
{
    public class TutorHubAPIDbContext: IdentityDbContext<Korisnik>
    {
        public TutorHubAPIDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Termini> Termini { get; set; }
        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<Zakazani> Zakazani { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRole = "630c2425-23cf-4da9-be77-e8dc8d20eb79";
            var professorRole = "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p";
            var adminRole = "fff052ce-b85c-4131-b667-617640718911";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRole,
                    ConcurrencyStamp = userRole,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = professorRole,
                    ConcurrencyStamp = professorRole,
                    Name = "Professor",
                    NormalizedName = "Professor".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRole,
                    ConcurrencyStamp = adminRole,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
