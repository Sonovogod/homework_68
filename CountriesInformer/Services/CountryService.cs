using CountriesInformer.DTO;
using CountriesInformer.Extensions;
using CountriesInformer.Models;
using CountriesInformer.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformer.Services;

public class CountryService : ICountryService
{
    private readonly CountriesDbContext _db;

    public CountryService(CountriesDbContext db)
    {
        _db = db;
    }

    public async Task<List<CountryDto>> GetAll()
    {
        List<Country> countries = await _db.Countries.ToListAsync();
        return countries.MapToCountriesDto();
    }

    public async Task<CountryDto> GetById(int id)
    {
        Country? country = await _db.Countries.FirstOrDefaultAsync(x => x.Id == id);
        return country.MapToCountryDto();
    }
}