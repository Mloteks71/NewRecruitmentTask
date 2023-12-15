using MediatR;
using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Repositories;
using System.ComponentModel.DataAnnotations;

namespace TedeeRecruitmentTask.Application.Areas.Trips.Commands;
public sealed class PostDeleteTrip : IRequest<ActionResult<PostDeleteTripResponse>>
{
    [Required]
    public int Id { get; private set; }

    public PostDeleteTrip(int id)
    {
        Id = id;
    }
}

public sealed class PostDeleteTripHandler : IRequestHandler<PostDeleteTrip, ActionResult<PostDeleteTripResponse>>
{
    private readonly ITripReadRepository _tripReadRepository;
    private readonly ITripWriteRepository _tripWriteRepository;

    public PostDeleteTripHandler(ITripReadRepository tripReadRepository, ITripWriteRepository tripRepository)
    {
        _tripReadRepository = tripReadRepository;
        _tripWriteRepository = tripRepository;
    }

    public async Task<ActionResult<PostDeleteTripResponse>> Handle(PostDeleteTrip request, CancellationToken cancellationToken)
    {
        var trip = await _tripReadRepository.FindAsync(request.Id, cancellationToken);

        if (trip is null)
        {
            return new NotFoundResult();
        }

        await _tripWriteRepository.DeleteAsync(trip, cancellationToken);

        return new NoContentResult();
    }
}