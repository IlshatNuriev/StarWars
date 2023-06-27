using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace StarWars.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    


    //public enum Movie
    //{
    //    [Display(Name = "Star Wars: Episode 4 - A New Hope (1977)")]
    //    StarWarsEpisode4ANewHope,

    //    [Display(Name = "Star Wars: Episode 5 - The Empire Strikes Back (1980)")]
    //    StarWarsEpisode5TheEmpireStrikesBack,

    //    [Display(Name = "Star Wars: Episode 6 - Return of the Jedi (1983)")]
    //    StarWarsEpisode6ReturnOfTheJedi,

    //    [Display(Name = "Star Wars: Episode 1 - The Phantom Menace (1999)")]
    //    StarWarsEpisode1ThePhantomMenace,

    //    [Display(Name = "Star Wars: Episode 2 - Attack of the Clones (2002)")]
    //    StarWarsEpisode2AttackOfTheClones,

    //    [Display(Name = "Star Wars: Episode 3 – Revenge of the Sith (2005)")]
    //    StarWarsEpisode3RevengeOfTheSith,

    //    [Display(Name = "Star Wars: The Clone Wars (2008)")]
    //    StarWarsTheCloneWars,

    //    [Display(Name = "Star Wars: Episode 7 - The Force Awakens (2015)")]
    //    StarWarsEpisode7TheForceAwakens,

    //    [Display(Name = "Rogue One: A Star Wars Story (2016)")]
    //    RogueOneAStarWarsStory,

    //    [Display(Name = "Star Wars: Episode 8 - The Last Jedi (2017)")]
    //    StarWarsEpisode8TheLastJedi,

    //    [Display(Name = "Solo: A Star Wars Story (2018)")]
    //    SoloAStarWarsStory,

    //    [Display(Name = "Star Wars: Episode 9 - The Rise of Skywalker (2019)")]
    //    StarWarsEpisode9TheRiseOfSkywalker
    //}
    

    
}
