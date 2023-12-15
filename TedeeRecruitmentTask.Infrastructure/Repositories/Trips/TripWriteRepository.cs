using Microsoft.EntityFrameworkCore;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.Entities;

namespace TedeeRecruitmentTask.Infrastructure.Repositories.Trips;
public class TripWriteRepository : ITripWriteRepository
{
    private readonly DbSet<Trip> _tripEntity;
    private readonly DbContext _dataContext;

    public TripWriteRepository(DbContext dataContext)
    {
        if (dataContext == null)
        {
            throw new ArgumentNullException(nameof(dataContext));
        }

        _tripEntity = dataContext.Set<Trip>();
        _dataContext = dataContext;
    }

    public async Task AddAsync(Trip trip, CancellationToken cancellationToken)
    {
        if (trip == null)
        {
            throw new ArgumentNullException(nameof(trip));
        }

        _tripEntity.Add(trip);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Trip trip, CancellationToken cancellationToken)
    {
        _tripEntity.Remove(trip);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }

    public async Task PatchAsync(Trip trip, CancellationToken cancellationToken)
    {
        _tripEntity.Update(trip);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
