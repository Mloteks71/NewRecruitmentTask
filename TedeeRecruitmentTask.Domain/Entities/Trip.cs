using FluentValidation;
using TedeeRecruitmentTask.Domain.Entities.AuditEntities;
using TedeeRecruitmentTask.Domain.Enums;
using TedeeRecruitmentTask.Domain.ValueObjects.Trip;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Domain.Entities;
public sealed class Trip : AuditEntity
{
    [Required]
    public int Id { get; private set; }
    [Required]
    public TripName Name { get; private set; }
    [Required]
    [EnumDataType(typeof(Country))]
    public TripCountry Country { get; private set; }
    public TripDescription Description { get; private set; }
    [Required]
    public TripStartDate StartDate { get; private set; }
    [Required]
    public TripSeatsCount SeatsCount { get; private set; }

    public ICollection<RegisteredEmail> RegisteredEmails { get; private set; }

    public Trip()
    {
    }

    public Trip(string name, Country country, string description, DateTimeOffset startDate, int numberOfSeats)
    {
        Name = name;
        Country = country;
        Description = description;
        StartDate = startDate;
        SeatsCount = numberOfSeats;
        RegisteredEmails = new List<RegisteredEmail>();

        var validator = new TripValidator();
        validator.ValidateAndThrow(this);
    }

    public class TripValidator : AbstractValidator<Trip>
    {
        public TripValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);

            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetCountry(Country country)
    {
        Country = country;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetStartDate(DateTimeOffset startDate)
    {
        StartDate = startDate;
    }

    public void SetNumberOfSeats(int numberOfSeats)
    {
        SeatsCount = numberOfSeats;
    }

    public RegisteredEmail RegisterEmail(string email)
    {
        var registeredEmail = new RegisteredEmail(email, Id);
        RegisteredEmails.Add(registeredEmail);

        return registeredEmail;
    }

    public void UnregisterEmail(string email)
    {
        var RegisteredEmailToDelete = RegisteredEmails.Single(x => x.Email == email);
        RegisteredEmails.Remove(RegisteredEmailToDelete);
    }

    public void Patch(TripName name, Country country, TripDescription description, TripStartDate startDate, TripSeatsCount seatsCount)
    {
        SetName(name);
        SetCountry(country);
        SetDescription(description);
        SetStartDate(startDate);
        SetNumberOfSeats(seatsCount);
    }
}
