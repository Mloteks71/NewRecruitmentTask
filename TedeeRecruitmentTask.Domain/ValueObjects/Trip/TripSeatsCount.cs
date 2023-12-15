using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.Trip;
public record TripSeatsCount : IValidatableObject
{
    public int Value { get; init; }

    public static implicit operator int(TripSeatsCount seatsCount) => seatsCount.Value;

    public static implicit operator TripSeatsCount(int seatsCount) => new(seatsCount);

    public TripSeatsCount()
    {
    }

    public TripSeatsCount(int value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new Trip_SeatsCountValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class Trip_SeatsCountValidator : AbstractValidator<int>
{
    public Trip_SeatsCountValidator()
    {
        RuleFor(x => x).GreaterThan(0);
    }
}