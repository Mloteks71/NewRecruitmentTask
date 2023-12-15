using Microsoft.EntityFrameworkCore;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Domain.Enums;

namespace TedeeRecruitmentTask.Infrastructure.Repositories.Trips;
public class TripReadRepository : ITripReadRepository
{
    private readonly DbSet<Trip> _tripEntity;

    public TripReadRepository(DbContext dataContext)
    {
        if (dataContext == null)
        {
            throw new ArgumentNullException(nameof(dataContext));
        }

        _tripEntity = dataContext.Set<Trip>();
    }

    public async Task<Trip> FindAsync(int id, CancellationToken cancellationToken)
    {
        return await _tripEntity.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<Trip> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _tripEntity
            .Include(x => x.RegisteredEmails)
            .SingleOrDefaultAsync((x => x.Id == id), cancellationToken);
    }

    public async Task<IEnumerable<TripDto>> GetTripsAsync(CancellationToken cancellationToken)
    {
        return await _tripEntity.Select(x => new TripDto(x)).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TripDto>> GetTripsAsync(Country country, CancellationToken cancellationToken)
    {
        return await _tripEntity.Where(x => x.Country == country).Select(x => new TripDto(x)).ToListAsync(cancellationToken);
    }

    public async Task<TripWithDescriptionDto> GetTripAsync(int id, CancellationToken cancellationToken)
    {
        return await _tripEntity.Where(x => x.Id == id).Select(x => new TripWithDescriptionDto(x)).SingleOrDefaultAsync(cancellationToken);
    }
}
