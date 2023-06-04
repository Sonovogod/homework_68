using CountriesInformer.Enums;

namespace CountriesInformer.Models;

public class Status
{
    public CustomStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}