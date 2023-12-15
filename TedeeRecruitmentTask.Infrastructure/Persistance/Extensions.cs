using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TedeeRecruitmentTask.Infrastructure.Persistance.DataLayer;

namespace TedeeRecruitmentTask.Infrastructure.Persistance;
public static class Extensions
{
    public static IServiceCollection AddSqlDatabase(this IServiceCollection services)
    {
        services.AddScoped<DbContext, DataContext>();
        services.AddDbContext<DataContext>(opt =>
            opt.UseInMemoryDatabase("Tedee"));

        return services;
    }
}
