using SuperHeroAPI.src.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}