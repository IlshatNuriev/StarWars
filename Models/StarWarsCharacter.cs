using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Data;
using StarWars.SeedData;

namespace StarWars.Models
{
    public enum Gender
    {
        [Display(Name = "Мужчина")]
        Male,

        [Display(Name = "Женщина")]
        Female

    }


    public class StarWarsCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int BirthYear { get; set; } 
        public string OriginPlanet { get; set; }
        public Gender Gender { get; set; }
        public string Race { get; set; }
        public double Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public Movie? Movie { get; set; }
        
        [NotMapped]
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();


        
        public StarWarsCharacter(string name, string originalName, int birthYear, string originPlanet, Gender gener, string race, 
            double height, string hairColor, string eyeColor, string description, List<Movie> movies) 
        {
            Name = name;
            OriginalName = originalName;
            BirthYear = birthYear;
            OriginPlanet = originPlanet;
            Gender = gener;
            Race = race;
            Height = height;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Description = description;
            Movies = movies;

        }

        public StarWarsCharacter()
        {

        }
        
    }
}
