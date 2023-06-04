using CountriesInformer.DTO;
using FluentValidation.Results;

namespace CountriesInformer.Services.Abstracts;

public interface ICountryService
{
    Task<List<CountryDto>> GetAll();
    Task<CountryDto?> GetById(int? id);
    Task<CountryDto?> GetByName(string name);
    ValidationResult? DataValidation(CountryDto? countryDto);
    Task<bool> Update(CountryDto countryDto);
    Task<bool> Add(CreateCountryDto countryDto);
    ValidationResult CreateValidation(CreateCountryDto countryDto);
    Task<bool> DeleteById(int? id);
}