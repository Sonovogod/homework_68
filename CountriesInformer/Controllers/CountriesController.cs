using CountriesInformer.DTO;
using CountriesInformer.Enums;
using CountriesInformer.Models;
using CountriesInformer.Services.Abstracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
                }
            };
            return Ok(response);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int? id)
    {
        try
        {
            if (id is null)
                throw new Exception("Передан пустой Id");
            
            CountryDto? model = await _countryService.GetById(id);
            if (model is null)
                throw new Exception("Страна по такому Id не найдена");
            
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
                    Message = $"{e.Message}",
                    StatusCode = CustomStatusCode.Error
                }
            };
            return Ok(response);
        }
    }
    
    [HttpGet("counrty")]
    public async Task<IActionResult> Get(string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Передано пустое название");
            
            CountryDto? model = await _countryService.GetByName(name);
            if (model is null)
                throw new Exception("Страна по такому названию не найдена");
            
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
                    Message = $"{e.Message}",
                    StatusCode = CustomStatusCode.Error
                }
            };
            return Ok(response);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(CountryDto? countryDto)
    {
        try
        {
            ValidationResult? result = _countryService.DataValidation(countryDto);
            if (result is { IsValid: true })
            {
                bool updateResult = await _countryService.Update(countryDto);
                if (updateResult)
                {
                    var response = new ResponseDto<CountryDto>
                    {
                        Status = new Status
                        {
                            StatusCode = CustomStatusCode.Success
                        }
                    };
                    return Ok(response);
                }
                
                var warningResponse = new ResponseDto<CountryDto>
                {
                    Status = new Status
                    {
                        StatusCode = CustomStatusCode.Warning,
                        Message = "Данные не были обновлены"
                    }
                };
                return Ok(warningResponse);
            }

            if (result is null)
                throw new Exception("Некорректные данные");
            string error = string.Join('/', result.Errors);
                throw new Exception($"{error}");
        
        }
        catch (Exception e)
        {
            var errorResponse = new ResponseDto<CountryDto>
            {
                Status = new Status
                {
                    StatusCode = CustomStatusCode.Error,
                    Message = $"{e.Message}"
                }
            };
            return Ok(errorResponse);
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateCountryDto? countryDto)
    {
        try
        {
            ValidationResult? result = _countryService.CreateValidation(countryDto);
            if (result is { IsValid: true })
            {
                bool addResult = await _countryService.Add(countryDto);
                if (addResult)
                {
                    var response = new ResponseDto<CountryDto>
                    {
                        Status = new Status
                        {
                            StatusCode = CustomStatusCode.Success
                        }
                    };
                    return Ok(response);
                }
                
                var warningResponse = new ResponseDto<CountryDto>
                {
                    Status = new Status
                    {
                        StatusCode = CustomStatusCode.Warning,
                        Message = "Данные не были добавлены"
                    }
                };
                return Ok(warningResponse);
            }

            if (result is null)
                throw new Exception("Некорректные данные");
            string error = string.Join('/', result.Errors);
            throw new Exception($"{error}");
        
        }
        catch (Exception e)
        {
            var errorResponse = new ResponseDto<CountryDto>
            {
                Status = new Status
                {
                    StatusCode = CustomStatusCode.Error,
                    Message = $"{e.Message}"
                }
            };
            return Ok(errorResponse);
        }
        
    }
}