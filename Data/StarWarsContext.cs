
using System.Configuration;
using System.Reflection.Metadata;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Data
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext (DbContextOptions<StarWarsContext> options)
            : base(options)
        {
         
            Database.EnsureCreated();
        }

        
        public DbSet<StarWarsCharacter> StarWarsCharacters { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StarWarsCharacter>()
                .HasMany(c => c.Movies)
                .WithMany();
                
        }




    }
}
