using CountriesInformer.DTO;

namespace CountriesInformer.Services.Abstracts;

public interface ICountryService
{
    Task<List<CountryDto>> GetAll();
    Task<CountryDto> GetById(int id);
}