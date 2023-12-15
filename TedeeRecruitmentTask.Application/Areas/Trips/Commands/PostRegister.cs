using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using TedeeRecruitmentTask.Domain.ValueObjects.RegisteredEmail;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Commands;
public sealed class PostRegister : IRequest<ActionResult<PostRegisterResponse>>
{
    [Required]
    public int Id { get; private set; }
    [Required]
    public RegisteredEmailEmail Email { get; private set; }

    public PostRegister(PostRegisterRequest body, int id)
    {
        Email = body.Email;
        Id = id;
    }
}

public sealed class PostRegisterHandler : IRequestHandler<PostRegister, ActionResult<PostRegisterResponse>>
{
    private readonly ITripWriteRepository _tripWriteRepository;
    private readonly ITripReadRepository _tripReadRepository;

    public PostRegisterHandler(ITripWriteRepository tripRepository, ITripReadRepository tripReadRepository)
    {
        _tripWriteRepository = tripRepository;
        _tripReadRepository = tripReadRepository;
    }

    public async Task<ActionResult<PostRegisterResponse>> Handle(PostRegister request, CancellationToken cancellationToken)
    {
        Domain.Entities.Trip trip = await _tripReadRepository.GetAsync(request.Id, cancellationToken);

        if (trip is null)
        {
            return new NotFoundResult();
        }

        if (trip.RegisteredEmails.Select(x => x.Email).Contains(request.Email))
        {
            return new ConflictResult();
        }

        var registeredEmail = trip.RegisterEmail(request.Email);

        await _tripWriteRepository.PatchAsync(trip, cancellationToken);

        return new PostRegisterResponse(registeredEmail.Id);
    }
}