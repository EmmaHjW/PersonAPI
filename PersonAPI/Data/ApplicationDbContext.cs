using Microsoft.EntityFrameworkCore;
using PersonAPI.Models;

namespace PersonAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSqlServer("Server=LAPTOP-EQE3P3DB;Database=PersonsLab3Db;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<Person>().HasData
            (
                new Person {PersonId = 1, FullName = "Emma Hjalmarsson Wahlström", PhoneNumber = "0738435459", BirthDate = new DateTime(1990, 03, 28, 0, 0, 0)},
                new Person {PersonId = 2, FullName = "Aldor Besher", PhoneNumber = "0738435455", BirthDate = new DateTime(1992, 06, 16, 0, 0, 0)},
                new Person {PersonId = 3, FullName = "Oskar Ullsten", PhoneNumber = "0738435465", BirthDate = new DateTime(1982, 02, 10, 0, 0, 0)}
            );
            // New table
            modelBuilder.Entity<Interest>(entity =>
            {
                entity.HasKey(e => e.InterestId);
                entity.Property(e => e.Description).IsRequired();
            });
            modelBuilder.Entity<Interest>().HasData
            (
                new Interest { InterestId = 1, Description = "Trail running", FK_PersonId = 1},
                new Interest { InterestId = 2, Description = "Food & Wine", FK_PersonId = 1 },
                new Interest { InterestId = 3, Description = "Coding", FK_PersonId = 2 }

            );
        }
        
    }
}
