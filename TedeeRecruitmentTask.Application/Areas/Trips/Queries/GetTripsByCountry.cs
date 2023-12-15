using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.Enums;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
public sealed class GetTripsByCountry : IRequest<ActionResult<GetTripsByCountryResponse>>
{
    public Country Country { get; init; }

    public GetTripsByCountry(Country country)
    {
        Country = country;
    }
}

public sealed class GetTripsByCountryHandler : IRequestHandler<GetTripsByCountry, ActionResult<GetTripsByCountryResponse>>
{
    private readonly ITripReadRepository _tripReadRepository;

    public GetTripsByCountryHandler(ITripReadRepository tripReadRepository)
    {
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<GetTripsByCountryResponse>> Handle(GetTripsByCountry request, CancellationToken cancellationToken)
    {
        var tripList = await _tripReadRepository.GetTripsAsync(request.Country, cancellationToken);

        return new GetTripsByCountryResponse(tripList);
    }
}