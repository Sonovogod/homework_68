using CountriesInformer.DTO;
using CountriesInformer.Extensions;
using CountriesInformer.Models;
using CountriesInformer.Services.Abstracts;
using CountriesInformer.Validations;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CountriesInformer.Services;

public class CountryService : ICountryService
{
    private readonly CountriesDbContext _db;
    private readonly CountryDtoValidator _validator;
    private readonly CreateCountryDtoValidator _createValidator;

    public CountryService(CountriesDbContext db, CountryDtoValidator validator, CreateCountryDtoValidator createValidator)
    {
        _db = db;
        _validator = validator;
        _createValidator = createValidator;
    }

    public async Task<List<CountryDto>> GetAll()
    {
        List<Country> countries = await _db.Countries.ToListAsync();
        return countries.MapToCountriesDto();
    }

    public async Task<CountryDto?> GetById(int? id)
    {
        Country? country = await _db.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (country is null)
            return null;
        
        return country.MapToCountryDto();
    }

    public async Task<CountryDto?> GetByName(string name)
    {
        Country? country = await _db.Countries.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        if (country is null)
            return null;
        
        return country.MapToCountryDto();
    }

    public ValidationResult? DataValidation(CountryDto? countryDto)
    {
        var result = _validator.Validate(countryDto);
        return result;
    }

    public async Task<bool> Update(CountryDto countryDto)
    {
        try
        {
            Country? country = _db.Countries.FirstOrDefault(x => x.Id == countryDto.Id);
            if (country is not null)
            {
                country.MapToCountryModel(countryDto);
                _db.Update(country);
                await _db.SaveChangesAsync();
            
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return false;
    }

    public async Task<bool> Add(CreateCountryDto countryDto)
    {
        try
        {
            Country country = countryDto.MapToCountryModel();
            
            await _db.AddAsync(country);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public ValidationResult CreateValidation(CreateCountryDto countryDto)
    {
        var result = _createValidator.Validate(countryDto);
        return result;
    }

    public async Task<bool> DeleteById(int? id)
    {
        try
        {
            Country? country = await _db.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country is not null)
            {
                _db.Countries.Remove(country);
                await _db.SaveChangesAsync();
            
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return false;
    }
}