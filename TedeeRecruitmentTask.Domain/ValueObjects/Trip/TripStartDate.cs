using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.Trip;
public record TripStartDate : IValidatableObject
{
    public DateTimeOffset Value { get; init; }

    public static implicit operator DateTimeOffset(TripStartDate seatsCount) => seatsCount.Value;

    public static implicit operator TripStartDate(DateTimeOffset seatsCount) => new(seatsCount);

    public TripStartDate()
    {
    }

    public TripStartDate(DateTimeOffset value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new Trip_TripStartDateValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class Trip_TripStartDateValidator : AbstractValidator<DateTimeOffset>
{
    public Trip_TripStartDateValidator()
    {
        RuleFor(x => x).LessThan(DateTime.UtcNow);
    }
}