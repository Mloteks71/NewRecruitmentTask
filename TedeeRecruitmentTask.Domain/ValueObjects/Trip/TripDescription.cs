using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.Trip;
public record TripDescription : IValidatableObject
{
    public string Value { get; init; }

    public static implicit operator string(TripDescription description) => description.Value;

    public static implicit operator TripDescription(string description) => new(description);

    public TripDescription()
    {
    }

    public TripDescription(string value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new Trip_DescriptionValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class Trip_DescriptionValidator : AbstractValidator<string>
{
    public Trip_DescriptionValidator()
    {
        RuleFor(x => x).MaximumLength(500);
    }
}