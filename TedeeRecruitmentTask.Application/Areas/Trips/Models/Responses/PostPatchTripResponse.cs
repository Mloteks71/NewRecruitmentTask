namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record PostPatchTripResponse
{
    public PostPatchTripResponse(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
