using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.ValueObjects.RegisteredEmail;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Commands;
public sealed class PostUnregister : IRequest<ActionResult<PostUnregisterResponse>>
{
    [Required]
    public int Id { get; private set; }
    [Required]
    public RegisteredEmailEmail Email { get; private set; }

    public PostUnregister(PostUnregisterRequest body, int id)
    {
        Email = body.Email;
        Id = id;
    }
}

public sealed class PostUnregisterHandler : IRequestHandler<PostUnregister, ActionResult<PostUnregisterResponse>>
{
    private readonly ITripWriteRepository _tripWriteRepository;
    private readonly ITripReadRepository _tripReadRepository;

    public PostUnregisterHandler(ITripWriteRepository tripRepository, ITripReadRepository tripReadRepository)
    {
        _tripWriteRepository = tripRepository;
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<PostUnregisterResponse>> Handle(PostUnregister request, CancellationToken cancellationToken)
    {
        Domain.Entities.Trip trip = await _tripReadRepository.GetAsync(request.Id, cancellationToken);

        if (trip is null || !trip.RegisteredEmails.Any(x => x.Email == request.Email))
        {
            return new NotFoundResult();
        }

        trip.UnregisterEmail(request.Email);

        await _tripWriteRepository.PatchAsync(trip, cancellationToken);

        return new PostUnregisterResponse();
    }
}