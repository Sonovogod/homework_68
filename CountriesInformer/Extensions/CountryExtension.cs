using CountriesInformer.DTO;
using CountriesInformer.Models;

namespace CountriesInformer.Extensions;

public static class CountryExtension
{
    public static List<CountryDto> MapToCountriesDto(this IEnumerable<Country> model)
    {
        List<CountryDto> dto = model.Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.Name,
            CapitalCity = x.CapitalCity,
            OfficialLanguage = x.OfficialLanguage
        }).ToList();
        return dto;
    }

    public static CountryDto MapToCountryDto(this Country model)
    {
        return new CountryDto()
        {
            Id = model.Id,
            Name = model.Name,
            CapitalCity = model.CapitalCity,
            OfficialLanguage = model.OfficialLanguage
        };
    }
}