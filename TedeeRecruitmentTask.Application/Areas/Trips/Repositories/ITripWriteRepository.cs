using TedeeRecruitmentTask.Domain.Entities;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
public interface ITripWriteRepository
{
    public Task AddAsync(Trip trip, CancellationToken cancellationToken);
    public Task DeleteAsync(Trip trip, CancellationToken cancellationToken);
    public Task PatchAsync(Trip trip, CancellationToken cancellationToken);
}
