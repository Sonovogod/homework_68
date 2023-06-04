using CountriesInformer.DTO;
using CountriesInformer.Enums;
using CountriesInformer.Models;
using CountriesInformer.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace CountriesInformer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : Controller
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<CountryDto> model = await _countryService.GetAll();
            var response = new ResponseDto<List<CountryDto>>
            {
                Entity = model,
                Status = new Status{StatusCode = CustomStatusCode.Success}
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            var response = new ResponseDto<List<CountryDto>>
            {
                Status = new Status
                {
                    Message = "Неизвестная ошибка",
                    StatusCode = CustomStatusCode.Error
                },
            };
            return Ok(response);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            CountryDto model = await _countryService.GetById(id);
            var response = new ResponseDto<CountryDto>
            {
                Entity = model,
                Status = new Status{StatusCode = CustomStatusCode.Success}
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            var response = new ResponseDto<CountryDto>
            {
                Status = new Status
                {
                    Message = "Неизвестная ошибка",
                    StatusCode = CustomStatusCode.Error
                },
            };
            return Ok(response);
        }
    }
}