using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using L8HeroesWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using L8HeroesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L8HeroesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {

        public readonly ApplicationDbContext db;

        public HeroController(ApplicationDbContext _db)
        {
            db = _db;
        }


        [HttpGet("GetAllHeroes", Name = "Hero")]
        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            return await db.HeroesList.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            Hero heroFromDb = await db.HeroesList.FindAsync(id);
            if (heroFromDb != null)
            {
                return await db.HeroesList.FindAsync(id);
            }
            else
            {

                return NotFound("No research entries found.");
            }


        }

        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero([FromBody] Hero hero)
        {


            Hero heroFromDb = await db.HeroesList.FindAsync(hero.Id);
            if (heroFromDb == null)
            {
                db.HeroesList.Add(hero);
                await db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetHero), new { id = hero.Id }, hero);
            }
            else
            {

                return BadRequest("Hero with that Id already exists");
            }

        }
    }
}

