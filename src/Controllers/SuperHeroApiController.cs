using SuperHeroAPI.Context;
using SuperHeroAPI.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperHeroApiController : ControllerBase
{
    private readonly DatabaseContext _context;

    public SuperHeroApiController(DatabaseContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToArrayAsync());
    }


    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetHero()
    {
        return Ok(await _context.SuperHeroes.ToListAsync());
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<List<SuperHero>>> GetById(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero == null)
        {
            return BadRequest("Sorry! Hero not found.");
        }

        return Ok(hero);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);

        if (dbHero == null)
        {
            return BadRequest("Sorry! Hero not found.");
        }

        dbHero.Name = hero.Name;
        dbHero.FirstName = hero.FirstName;
        dbHero.LastName = hero.LastName;

        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(id);

        if (dbHero == null)
        {
            return BadRequest("Sorry! Hero not found.");
        }

        _context.SuperHeroes.Remove(dbHero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
}