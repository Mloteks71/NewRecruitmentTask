using Microsoft.Extensions.DependencyInjection;
using TedeeRecruitmentTask.Application.Services;

namespace TedeeRecruitmentTask.Infrastructure.Services;
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();

        return services;
    }
}
