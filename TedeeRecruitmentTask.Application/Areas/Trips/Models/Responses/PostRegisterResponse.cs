namespace TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
public sealed record PostRegisterResponse
{
    public PostRegisterResponse(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
