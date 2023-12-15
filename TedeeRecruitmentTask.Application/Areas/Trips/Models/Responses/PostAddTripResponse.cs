namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record PostAddTripResponse
{
    public PostAddTripResponse(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
