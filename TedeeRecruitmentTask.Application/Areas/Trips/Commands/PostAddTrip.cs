using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.Entities;
using TedeeRecruitmentTask.Domain.Enums;
using TedeeRecruitmentTask.Domain.ValueObjects.Trip;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Commands;
public sealed class PostAddTrip : IRequest<ActionResult<PostAddTripResponse>>
{
    [Required]
    public TripName Name { get; set; }
    [Required]
    [EnumDataType(typeof(Country))]
    public TripCountry Country { get; set; }
    [Required]
    public TripDescription Description { get; set; }
    [Required]
    public TripStartDate StartDate { get; set; }
    [Required]
    public TripSeatsCount SeatsCount { get; set; }

    public PostAddTrip(PostAddTripRequest body)
    {
        Name = body.Name;
        Country = body.Country;
        Description = body.Description;
        StartDate = body.StartDate;
        SeatsCount = body.SeatsCount;
    }
}

public sealed class PostAddTripHandler : IRequestHandler<PostAddTrip, ActionResult<PostAddTripResponse>>
{
    private readonly ITripWriteRepository _tripWriteRepository;

    public PostAddTripHandler(ITripWriteRepository tripRepository)
    {
        _tripWriteRepository = tripRepository;
    }

    public async Task<ActionResult<PostAddTripResponse>> Handle(PostAddTrip request, CancellationToken cancellationToken)
    {
        var trip = new Trip(request.Name, request.Country, request.Description, request.StartDate, request.SeatsCount);

        await _tripWriteRepository.AddAsync(trip, cancellationToken);

        return new PostAddTripResponse(trip.Id);
    }
}