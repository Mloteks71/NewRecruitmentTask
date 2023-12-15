using TedeeRecruitmentTask.Domain.Entities.AuditEntities;
using TedeeRecruitmentTask.Domain.ValueObjects.RegisteredEmail;

namespace TedeeRecruitmentTask.Domain.Entities;
public sealed class RegisteredEmail : AuditEntity
{
    public int Id { get; private set; }
    public RegisteredEmailEmail Email { get; private set; }
    public int TripId { get; private set; }
    public Trip Trip { get; private set; }

    public RegisteredEmail()
    {
    }

    public RegisteredEmail(string email, int tripId)
    {
        Email = email;
        TripId = tripId;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public void SetTripId(int tripId)
    {
        TripId = tripId;
    }

    public void SetTrip(Trip trip)
    {
        Trip = trip;
    }
}