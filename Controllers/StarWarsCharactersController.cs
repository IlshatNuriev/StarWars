using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StarWars.Data;
using StarWars.Models;
using StarWars.SeedData;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsCharactersController : ControllerBase
    {
        private readonly StarWarsContext _context;

        public StarWarsCharactersController(StarWarsContext context)
        {
            _context = context;
        }

        // GET: api/StarWarsCharacters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarWarsCharacter>>> GetStarWarsCharacter(int? movieId)
        {
                        
            if (_context.StarWarsCharacters == null)
            {
                return NotFound();
            }

            if (movieId != null && movieId != 0) 
            {
                List<StarWarsCharacter> filtredCharacters = new();
                foreach (var  character in await _context.StarWarsCharacters.Include(m => m.Movies).ToListAsync())
                {
                    
                    List<Movie> movies = (List<Movie>)character.Movies;
                    for(int i = 0; i < movies.Count; i++)
                    {
                        if(movieId == movies[i].Id)
                        {
                            filtredCharacters.Add(character);
                            break;
                        }
                    }
                }

                return filtredCharacters;
            }
            else
            {
                return await _context.StarWarsCharacters.Include(m => m.Movies).ToListAsync();
            }

        }

        // GET: api/StarWarsCharacters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StarWarsCharacter>> GetStarWarsCharacter(int id)
        {
            if (_context.StarWarsCharacters == null)
            {
                return NotFound();
            }
            var starWarsCharacter = await _context.StarWarsCharacters.Include(m => m.Movies).FirstOrDefaultAsync(c => c.Id == id);


            if (starWarsCharacter == null)
            {
                return NotFound();
            }

            return starWarsCharacter;
        }

        // PUT: api/StarWarsCharacters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarWarsCharacter(int id, StarWarsCharacter starWarsCharacter)
        {
            if (id != starWarsCharacter.Id)
            {
                return BadRequest();
            }

            _context.Entry(starWarsCharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarWarsCharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StarWarsCharacters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StarWarsCharacter>> PostStarWarsCharacter(StarWarsCharacter starWarsCharacter)
        {
            if (_context.StarWarsCharacters == null)
            {
                return Problem("Entity set 'StarWarsContext.StarWarsCharacter'  is null.");
            }

            _context.StarWarsCharacters.Add(starWarsCharacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStarWarsCharacter", new { id = starWarsCharacter.Id }, starWarsCharacter);
        }

        // DELETE: api/StarWarsCharacters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarWarsCharacter(int id)
        {
            if (_context.StarWarsCharacters == null)
            {
                return NotFound();
            }
            var starWarsCharacter = await _context.StarWarsCharacters.FindAsync(id);
            if (starWarsCharacter == null)
            {
                return NotFound();
            }

            _context.StarWarsCharacters.Remove(starWarsCharacter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StarWarsCharacterExists(int id)
        {
            return (_context.StarWarsCharacters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public static List<Movie> SetMovies(List<int> moviesId, StarWarsContext _context)
        {
            var movies = _context.Movies.ToList();
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
