namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record GetTripResponse
{
    public TripWithDescriptionDto Trip { get; init; }

    public GetTripResponse(TripWithDescriptionDto trip)
    {
        Trip = trip;
    }
}
