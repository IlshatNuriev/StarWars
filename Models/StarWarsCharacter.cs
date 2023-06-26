namespace StarWars.Models
{
    public enum Gender
    {

    }
    public class StarWarsCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string OriginPlanet { get; set; }
        public Gender Gender { get; set; }
        public string Race { get; set; }
        public double Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }






    }
}
