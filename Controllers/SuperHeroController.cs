using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero 
                {
                    Id = 1,
                    Name ="Spider Man",
                    FirstName ="Peter",
                    LastName = "Parket",
                    BornPlace = "New York"
                },
                 new SuperHero
                {
                    Id = 2,
                    Name ="Iron Man",
                    FirstName ="Tony",
                    LastName = "Stark",
                    BornPlace = "Long Island"
                }
            };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero); 
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> PutHero(SuperHero request)
        {
            var Dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (Dbhero == null)
                return BadRequest("Hero not found.");

            Dbhero.Name = request.Name;
            Dbhero.FirstName = request.FirstName;
            Dbhero.LastName = request.LastName;   
            Dbhero.BornPlace = request.BornPlace;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dBhero = await _context.SuperHeroes.FindAsync(id);
            if (dBhero == null)
                return BadRequest("Hero not found.");

            _context.SuperHeroes.Remove(dBhero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
