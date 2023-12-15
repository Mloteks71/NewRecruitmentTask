namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record GetTripsResponse
{
    public IEnumerable<TripDto> Trips { get; init; }

    public GetTripsResponse(IEnumerable<TripDto> trips)
    {
        Trips = trips;
    }
}
