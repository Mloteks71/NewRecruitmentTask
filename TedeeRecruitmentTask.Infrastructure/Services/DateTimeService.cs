using TedeeRecruitmentTask.Application.Services;

namespace TedeeRecruitmentTask.Infrastructure.Services;
public class DateTimeService : IDateTimeService
{
    DateTimeOffset _dateTimeNow;
    DateTimeOffset _dateTimeUtcNow;

    public DateTimeService()
    {
        _dateTimeNow = DateTimeOffset.Now;
        _dateTimeUtcNow = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset Now => _dateTimeNow;

    public DateTimeOffset UtcNow => _dateTimeUtcNow;
}
