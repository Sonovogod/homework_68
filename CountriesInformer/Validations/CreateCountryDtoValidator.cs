using System.Text.RegularExpressions;
using CountriesInformer.DTO;
using FluentValidation;

namespace CountriesInformer.Validations;

public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
{
    public CreateCountryDtoValidator()
    {
        RuleFor(country => country.Name)
            .MaximumLength(30).WithMessage("Слишком длинное название")
            .MinimumLength(3).WithMessage("Слишком короткое название")
            .NotEmpty().WithMessage("Название не должно быть пустым")
            .Must(name =>
            {
                string pattern = "^[a-zA-Z]+$";
                if (!string.IsNullOrEmpty(name))
                {
                    if(Regex.IsMatch(name, pattern))
                        return true;
                }

                return false;
            })
            .WithMessage("Поле должно содержать только латинские буквы");
        
        RuleFor(country => country.CapitalCity)
            .MaximumLength(30).WithMessage("Слишком длинное название")
            .MinimumLength(3).WithMessage("Слишком короткое название")
            .NotEmpty().WithMessage("Название не должно быть пустым")
            .Must(name =>
            {
                string pattern = "^[a-zA-Z]+$";
                if (!string.IsNullOrEmpty(name))
                {
                    if(Regex.IsMatch(name, pattern))
                        return true;
                }

                return false;
            })
            .WithMessage("Поле должно содержать только латинские буквы");
        
        RuleFor(country => country.OfficialLanguage)
            .MaximumLength(15).WithMessage("Слишком длинное название")
            .MinimumLength(3).WithMessage("Слишком короткое название")
            .NotEmpty().WithMessage("Название не должно быть пустым")
            .Must(name =>
            {
                string pattern = "^[a-zA-Z]+$";
                if (!string.IsNullOrEmpty(name))
                {
                    if(Regex.IsMatch(name, pattern))
                        return true;
                }

                return false;
            })
            .WithMessage("Поле должно содержать только латинские буквы");
    }
}