using Microsoft.Extensions.DependencyInjection;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Infrastructure.Persistance;
using TedeeRecruitmentTask.Infrastructure.Repositories.Trips;

namespace TedeeRecruitmentTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITripReadRepository, TripReadRepository>();
        services.AddScoped<ITripWriteRepository, TripWriteRepository>();

        services.AddSqlDatabase();

        return services;
    }
}
