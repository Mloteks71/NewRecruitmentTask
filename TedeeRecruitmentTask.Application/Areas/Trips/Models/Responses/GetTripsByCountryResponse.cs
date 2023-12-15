namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record GetTripsByCountryResponse
{
    public IEnumerable<TripDto> Trips { get; init; }

    public GetTripsByCountryResponse(IEnumerable<TripDto> trips)
    {
        Trips = trips;
    }
}
