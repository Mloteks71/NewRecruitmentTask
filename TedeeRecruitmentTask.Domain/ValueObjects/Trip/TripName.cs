using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.Trip;
public record TripName : IValidatableObject
{
    public string Value { get; init; }

    public static implicit operator string(TripName name) => name.Value;

    public static implicit operator TripName(string name) => new(name);

    public TripName()
    {
    }

    public TripName(string value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new Trip_NameValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class Trip_NameValidator : AbstractValidator<string>
{
    public Trip_NameValidator()
    {
        RuleFor(x => x).MaximumLength(50);
    }
}