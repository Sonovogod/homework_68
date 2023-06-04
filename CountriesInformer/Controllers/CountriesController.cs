using CountriesInformer.DTO;
using CountriesInformer.Enums;
using CountriesInformer.Models;
using CountriesInformer.Services.Abstracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CountriesInformer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : Controller
{
    private readonly ICountryService _countryService;
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ICountryService countryService, ILogger<CountriesController> logger)
    {
        _countryService = countryService;
        _logger = logger;
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
            _logger.LogTrace(e.StackTrace);
            _logger.LogError("CountriesController | Get all countries error: {Message}", e.Message);
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
        _logger.LogInformation("CountriesController | Input data id: {Id}", id);
        try
        {
            if (id is null)
            {
                _logger.LogInformation("CountriesController | id is null");
                throw new Exception("Передан пустой Id");
            }

            CountryDto? model = await _countryService.GetById(id);
            if (model is null)
            {
                _logger.LogInformation("CountriesController | Country is not found");
                throw new Exception("Страна по такому Id не найдена");
            }
            
            var response = new ResponseDto<CountryDto>
            {
                Entity = model,
                Status = new Status{StatusCode = CustomStatusCode.Success}
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogTrace(e.StackTrace);
            _logger.LogError("CountriesController | Get country by id error: {Message}", e.Message);
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
            _logger.LogInformation("CountriesController | Get country by name input data: {Name}", name);
            if (string.IsNullOrEmpty(name))
            {
                _logger.LogError("CountriesController | Get countries by name error: input data is null or empty");
                throw new Exception("Передано пустое название");
            }
            
            CountryDto? model = await _countryService.GetByName(name);
            if (model is null)
            {
                _logger.LogError("CountriesController | Get countries by name error: not found");
                throw new Exception("Страна по такому названию не найдена");
            }
            
            var response = new ResponseDto<CountryDto>
            {
                Entity = model,
                Status = new Status{StatusCode = CustomStatusCode.Success}
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogTrace(e.StackTrace);
            _logger.LogError("CountriesController | Get country by name error: {Message}", e.Message);
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
            _logger.LogInformation("CountriesController | Put update country: {Id}/{Name}/{City}/{Language}", countryDto.Id, countryDto.Name, countryDto.CapitalCity, countryDto.OfficialLanguage);
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
                            StatusCode = CustomStatusCode.Success,
                            Message = "Данные успешно обновлены"
                        }
                    };
                    return Ok(response);
                }
                _logger.LogWarning("CountriesController | Data in not updated error in the _countryService");
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
            {
                _logger.LogError("CountriesController | Put valid result is null");
                throw new Exception("Некорректные данные");
            }
            string error = string.Join('/', result.Errors);
                throw new Exception($"{error}");
        
        }
        catch (Exception e)
        {
            _logger.LogError("CountriesController | Put country error: {Message}", e.Message);
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
            _logger.LogInformation("CountriesController | Post create country: {Name}/{City}/{Language}", countryDto.Name, countryDto.CapitalCity, countryDto.OfficialLanguage);
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
                            StatusCode = CustomStatusCode.Success,
                            Message = "Данные успешно добавлены"
                        }
                    };
                    return Ok(response);
                }
                _logger.LogWarning("CountriesController | Data in not added error in the _countryService");
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
            {
                _logger.LogError("CountriesController | Post valid result is null");
                throw new Exception("Некорректные данные");
            }
            string error = string.Join('/', result.Errors);
            throw new Exception($"{error}");
        
        }
        catch (Exception e)
        {
            _logger.LogError("CountriesController | Post add country error: {Message}", e.Message);
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
    
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            _logger.LogInformation("CountriesController | Delete input data id: {Id}", id);
            if (id is null)
            {
                _logger.LogError("CountriesController | Delete country id is null ");
                throw new Exception("Передан пустой Id");
            }
            
            bool deleteResult = await _countryService.DeleteById(id);
            if (deleteResult)
            {
                var response = new ResponseDto<CountryDto>
                {
                    Status = new Status
                    {
                        StatusCode = CustomStatusCode.Success,
                        Message = "Страна удалена"
                    }
                };
                return Ok(response);
            }
            
            _logger.LogInformation("CountriesController | Delete input data id error / not founded: {Id}", id);
            var errorResponse = new ResponseDto<CountryDto>
            {
                Status = new Status
                {
                    StatusCode = CustomStatusCode.Error,
                    Message = "Страна по указанному Id не была удалена"
                }
            };
            return Ok(errorResponse);

        }
        catch (Exception e)
        {
            _logger.LogError("CountriesController | Delete country error: {Message}", e.Message);
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