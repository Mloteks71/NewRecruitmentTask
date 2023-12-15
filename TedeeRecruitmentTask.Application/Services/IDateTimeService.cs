namespace TedeeRecruitmentTask.Application.Services;
public interface IDateTimeService
{
    DateTimeOffset Now { get; }
    DateTimeOffset UtcNow { get; }
}
