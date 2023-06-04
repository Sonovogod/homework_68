using CountriesInformer.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformer.Models;

public class CountriesDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public CountriesDbContext(DbContextOptions<CountriesDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CountriesSeed();
    }
}