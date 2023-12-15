using FluentValidation;
using TedeeRecruitmentTask.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.Trip;
public record TripCountry : IValidatableObject
{
    public Country Value { get; init; }

    public static implicit operator Country(TripCountry country) => country.Value;

    public static implicit operator TripCountry(Country country) => new(country);

    public TripCountry()
    {
    }

    public TripCountry(Country value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new Trip_CountryValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class Trip_CountryValidator : AbstractValidator<Country>
{
    public Trip_CountryValidator()
    {
        RuleFor(x => x).IsInEnum();
    }
}