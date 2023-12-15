using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Domain.Enums;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
public interface ITripReadRepository
{
    public Task<Trip> FindAsync(int id, CancellationToken cancellationToken);
    public Task<Trip> GetAsync(int id, CancellationToken cancellationToken);
    public Task<IEnumerable<TripDto>> GetTripsAsync(CancellationToken cancellationToken);
    public Task<IEnumerable<TripDto>> GetTripsAsync(Country country, CancellationToken cancellationToken);

    public Task<TripWithDescriptionDto> GetTripAsync(int id, CancellationToken cancellationToken);
}
