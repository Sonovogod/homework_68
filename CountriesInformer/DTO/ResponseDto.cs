using CountriesInformer.Models;

namespace CountriesInformer.DTO;

public class ResponseDto<T>
{
    public T? Entity { get; set; }
    public Status? Status { get; set; }
}