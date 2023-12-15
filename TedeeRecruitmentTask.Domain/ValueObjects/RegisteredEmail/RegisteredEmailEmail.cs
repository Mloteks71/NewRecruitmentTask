using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.ValueObjects.RegisteredEmail;
public record RegisteredEmailEmail : IValidatableObject
{
    public string Value { get; init; }

    public static implicit operator string(RegisteredEmailEmail registeredEmailEmail) => registeredEmailEmail.Value;

    public static implicit operator RegisteredEmailEmail(string registeredEmailEmail) => new(registeredEmailEmail);

    public RegisteredEmailEmail()
    {
    }

    public RegisteredEmailEmail(string value)
    {
        Value = value;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new RegisteredEmail_EmailValidator();
        var validationResults = validator.Validate(this);

        if (!validationResults.IsValid)
        {
            return validationResults.Errors.Select(x => new ValidationResult(x.ErrorMessage));
        }

        return new List<ValidationResult>();
    }
}

public class RegisteredEmail_EmailValidator : AbstractValidator<string>
{
    public RegisteredEmail_EmailValidator()
    {
        RuleFor(x => x).MaximumLength(500);
    }
}