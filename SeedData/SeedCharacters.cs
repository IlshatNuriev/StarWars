using System.Collections.ObjectModel;
using System.Xml.Linq;
using Microsoft.Build.Evaluation;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using StarWars.Data;
using StarWars.Models;

namespace StarWars.SeedData
{

    public class SeedCharacters
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new StarWarsContext(serviceProvider.GetRequiredService<DbContextOptions<StarWarsContext>>()))
            {
                if (context.StarWarsCharacters.Any())
                {
                    return;
                }
                else
                {
                    var movies = context.Movies.ToList();
                     //new List<Movie>()
                   // {
                   //     new Movie() { Id = 0, Name = "Star Wars: Episode 1 - The Phantom Menace (1999)"},
                   //     new Movie() { Id = 1, Name = "Star Wars: Episode 2 - Attack of the Clones (2002)"},
                   //     new Movie() { Id = 2, Name = "Star Wars: Episode 3 – Revenge of the Sith (2005)"},
                   //     new Movie() { Id = 3, Name = "Star Wars: Episode 4 - A New Hope (1977)" },
                   //     new Movie() { Id = 4, Name = "Star Wars: Episode 5 - The Empire Strikes Back (1980)"},
                   //     new Movie() { Id = 5, Name = "Star Wars: Episode 6 - Return of the Jedi (1983)"},
                   //     new Movie() { Id = 6, Name = "Star Wars: Episode 7 - The Force Awakens (2015)"},
                   //     new Movie() { Id = 7, Name = "Star Wars: Episode 8 - The Last Jedi (2017)"},
                   //     new Movie() { Id = 8, Name = "Star Wars: Episode 9 - The Rise of Skywalker (2019)"},
                   //     new Movie() { Id = 9, Name = "Star Wars: The Clone Wars (2008)"},
                   //     new Movie() { Id = 10, Name = "Rogue One: A Star Wars Story (2016)"},
                   //     new Movie() { Id = 11, Name = "Solo: A Star Wars Story (2018)"}
                   //};

                    var id = new List<int>() { 1, 3, 5, 6, 7, 8, 9 };
                    

                    var yoda = new StarWarsCharacter()
                    {
                        Name = "Йода",
                        OriginalName = "Yoda",
                        BirthYear = int.Parse("896"),
                        OriginPlanet = "Дагоба",
                        Gender = Gender.Male,
                        Race = "Йода",
                        Height = 0.66,
                        HairColor = "Белый",
                        EyeColor = "Зеленый",
                        Description = "Йода (англ. Yoda) — гранд-мастер Ордена джедаев, был одним из самых сильных и мудрых джедаев своего времени. " +
                            "Место в Совете получил спустя примерно сотню лет после рождения. Обладая долголетием, он достиг титула гранд-мастера в возрасте " +
                            "примерно 600 лет. Йода сумел выжить во время приказа 66. После неудачной дуэли с Дартом Сидиусом ушел в добровольное изгнание на " +
                            "планету Дагоба, где и умер естественной смертью в 4 ПБЯ. Родная планета и раса Йоды неизвестны.Магистр Йода был одним из " +
                            "сильнейших джедаев своего времени. Он был самым мудрым из них. Во владении световым мечом с Йодой могли сравниться только Мейс Винду, " +
                            "Энакин Скайуокер, Оби-Ван Кеноби, граф Дуку и Дарт Сидиус.",
                        Movies = SetMovies(movies, id)


                    };

                    id.Clear();
                    id.AddRange(new List<int>() {1, 2, 3, 11 });
                

                    var anakinSkywalker = new StarWarsCharacter()
                    {
                        Name = "Энакин Скайуокер",
                        OriginalName = "Anakin Skywalker",
                        BirthYear = int.Parse("42"),
                        OriginPlanet = "Татуин",
                        Gender = Gender.Male,
                        Race = "Человек",
                        Height = 1.88,
                        HairColor = "Русый",
                        EyeColor = "Голубой",
                        Description = "Энакин Скайуокер (англ. Anakin Skywalker, сокращённо Эни) — легендарный чувствительный к Силе человек, " +
                            "мужчина, который служил Галактической Республике как рыцарь-джедай, позже служивший Галактической Империи и командовавший " +
                            "её войсками, как Лорд ситхов Дарт Вейдер. Рождённый Шми Скайуокер, в юности стал тайным мужем сенатора с Набу, " +
                            "Падме Амидалы Наберри. Он был отцом гранд-мастера Люка Скайуокера, рыцаря-джедая Леи Органы-Соло и дедом Бена Скайуокера. " +
                            "Далёкими потомками Энакина Скайуокера были Нат, Кол и Кейд Скайуокеры.",
                        Movies = SetMovies(movies, id)

                        
                    };

                    id.Clear();

                    id.AddRange(new List<int>() { 3, 4, 5, 6, 7, 8, 9, 11 });

                    var leiaOrgana = new StarWarsCharacter()
                    {
                        Name = "Лея Органа",
                        OriginalName = "Leia Organa",
                        BirthYear = int.Parse("19"),
                        OriginPlanet = "Полис-Масса",
                        Gender = Gender.Female,
                        Race = "Человек",
                        Height = 1.50,
                        HairColor = "Тёмно-каштановый",
                        EyeColor = "Карие",
                        Description = "Лея Органа-Соло (англ. Leia Organa Solo) (имя при рождении — Лея Амидала Скайуокер) — " +
                            "дочь рыцаря-джедая Энакина Скайуокера и сенатора Падме Амидалы Наберри, а также сестра-близнец Люка Скайуокера. " +
                            "После рождения её удочерили Бейл Органа и королева Бреха, сделав её принцессой Альдераана. Получившая прекрасное " +
                            "образование сенатора, Органа была известна, как непоколебимый лидер во время Галактической гражданской войны и " +
                            "других последующих галактических конфликтов, став одним из величайших героев Галактики. Позднее она вышла замуж за " +
                            "Хана Соло и стала матерью троих детей: Джейны, Джейсена и Энакина. Незадолго до начала Роевой войны, Лея, сама того не зная, " +
                            "стала бабушкой дочери Джейсена — Алланы.",
                        Movies = SetMovies(movies, id)

                    };

                    id.Clear();

                    id.AddRange(new List<int>() { 4, 5, 6, 7, 9, 12 });

                    var hanSolo = new StarWarsCharacter()
                    {
                        Name = "Хан Соло",
                        OriginalName = "Han Solo",
                        BirthYear = int.Parse("29"),
                        OriginPlanet = "Кореллия",
                        Gender = Gender.Male,
                        Race = "Человек",
                        Height = 1.80,
                        HairColor = "Каштановый",
                        EyeColor = "Карий",
                        Description = "Хан Соло (англ. Han Solo) — знаменитый кореллианин, прославившийся на всю Галактику как участник Восстания " +
                            "против Галактической Империи. Родителями Хана были Джонаш и Джейна Соло, которые исчезли когда ему было не больше двух лет от роду. " +
                            "Его отец был принцем и потомком короля Беретрона э Соло, который установил демократический режим в Кореллианской Империи. " +
                            "У Хана было тяжелое детство, но он сумел порвать с прошлым и поступить на службу в Империю. Крест на своей карьере Соло поставил, " +
                            "когда заступился за раба-вуки Чубакку. Вместе они сбежали и со временем стали напарниками. " +
                            "Хан приобрел корабль «Тысячелетний сокол» и стал контрабандистом.",
                        Movies = SetMovies(movies, id)
                    };

                    context.StarWarsCharacters.AddRange(yoda, anakinSkywalker, leiaOrgana, hanSolo);
                    context.SaveChanges();
                }

            }
            
        }
        public static List<Movie> SetMovies(List<Movie> movies, List<int> moviesId)
        {
            List<Movie> selectedMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {

                for (int i = 0; i < moviesId.Count && selectedMovies.Count != moviesId.Count; i++)
                {
                    if (movie.Id == moviesId[i])
                    {
                        selectedMovies.Add(movie);
                        break;
                    }
                }
                if (selectedMovies.Count == moviesId.Count)
                {
                    break;
                }

            }
            return selectedMovies;
        }
    }
}






        
        

    
    

    
    

    
    

    
    

    
    

    
    

   
    

    
    

    
    
