using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
public sealed class GetTrips : IRequest<ActionResult<GetTripsResponse>>
{
    public GetTrips()
    {
    }
}

public sealed class GetTripsHandler : IRequestHandler<GetTrips, ActionResult<GetTripsResponse>>
{
    private readonly ITripReadRepository _tripReadRepository;

    public GetTripsHandler(ITripReadRepository tripReadRepository)
    {
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<GetTripsResponse>> Handle(GetTrips request, CancellationToken cancellationToken)
    {
        var tripList = await _tripReadRepository.GetTripsAsync(cancellationToken);

        return new GetTripsResponse(tripList);
    }
}