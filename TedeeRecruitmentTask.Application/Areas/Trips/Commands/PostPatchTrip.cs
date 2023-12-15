using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.Enums;
using TedeeRecruitmentTask.Domain.ValueObjects.Trip;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Commands;
public sealed class PostPatchTrip : IRequest<ActionResult<PostPatchTripResponse>>
{
    [Required]
    public int Id { get; private set; }
    [Required]
    public TripName Name { get; private set; }
    [Required]
    [EnumDataType(typeof(Country))]
    public TripCountry Country { get; private set; }
    [Required]
    public TripDescription Description { get; private set; }
    [Required]
    public TripStartDate StartDate { get; private set; }
    [Required]
    public TripSeatsCount SeatsCount { get; private set; }

    public PostPatchTrip(PostPatchTripRequest body, int id)
    {
        Name = body.Name;
        Country = body.Country;
        Description = body.Description;
        StartDate = body.StartDate;
        SeatsCount = body.SeatsCount;
        Id = id;
    }
}

public sealed class PostPatchTripHandler : IRequestHandler<PostPatchTrip, ActionResult<PostPatchTripResponse>>
{
    private readonly ITripWriteRepository _tripWriteRepository;
    private readonly ITripReadRepository _tripReadRepository;

    public PostPatchTripHandler(ITripWriteRepository tripRepository, ITripReadRepository tripReadRepository)
    {
        _tripWriteRepository = tripRepository;
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<PostPatchTripResponse>> Handle(PostPatchTrip request, CancellationToken cancellationToken)
    {
        var trip = await _tripReadRepository.FindAsync(request.Id, cancellationToken);

        if (trip is null)
        {
            return new NotFoundResult();
        }

        trip.Patch(request.Name, request.Country, request.Description, request.StartDate, request.SeatsCount);

        await _tripWriteRepository.PatchAsync(trip, cancellationToken);

        return new PostPatchTripResponse(trip.Id);
    }
}