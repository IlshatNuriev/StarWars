using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Data;
using StarWars.Models;

namespace StarWars.SeedData
{
    public class SeedMovies
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StarWarsContext(serviceProvider.GetRequiredService<DbContextOptions<StarWarsContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                else
                {
                    context.Movies.AddRange(
                        new Movie() { Name = "Star Wars: Episode 1 - The Phantom Menace (1999)" },
                        new Movie() { Name = "Star Wars: Episode 2 - Attack of the Clones (2002)" },
                        new Movie() { Name = "Star Wars: Episode 3 – Revenge of the Sith (2005)" },
                        new Movie() { Name = "Star Wars: Episode 4 - A New Hope (1977)" },
                        new Movie() { Name = "Star Wars: Episode 5 - The Empire Strikes Back (1980)" },
                        new Movie() { Name = "Star Wars: Episode 6 - Return of the Jedi (1983)" },
                        new Movie() { Name = "Star Wars: Episode 7 - The Force Awakens (2015)" },
                        new Movie() { Name = "Star Wars: Episode 8 - The Last Jedi (2017)" },
                        new Movie() { Name = "Star Wars: Episode 9 - The Rise of Skywalker (2019)" },
                        new Movie() { Name = "Star Wars: The Clone Wars (2008)" },
                        new Movie() { Name = "Rogue One: A Star Wars Story (2016)" },
                        new Movie() { Name = "Solo: A Star Wars Story (2018)" });
                    context.SaveChanges();
                }
            }
        }
    }
}
