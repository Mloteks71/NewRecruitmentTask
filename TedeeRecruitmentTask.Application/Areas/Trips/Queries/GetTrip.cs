using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
public sealed class GetTrip : IRequest<ActionResult<GetTripResponse>>
{
    public int Id { get; set; }

    public GetTrip(int id)
    {
        Id = id;
    }
}

public sealed class GetTripHandler : IRequestHandler<GetTrip, ActionResult<GetTripResponse>>
{
    private readonly ITripReadRepository _tripReadRepository;

    public GetTripHandler(ITripReadRepository tripReadRepository)
    {
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<GetTripResponse>> Handle(GetTrip request, CancellationToken cancellationToken)
    {
        var trip = await _tripReadRepository.GetTripAsync(request.Id, cancellationToken);

        if (trip is null)
        {
            return new NotFoundResult();
        }

        return new GetTripResponse(trip);
    }
}