using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero {Id = 1, Name ="Spider Man", FirstName ="Peter", LastName = "Parket", BornPlace = "New York"}
            };
            return Ok(heroes);
        }
        
    }
}
