using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpGet("/api/my/[controller]/{id}")]
    [SwaggerOperation(Summary = "Get trip.")]
    [SwaggerResponse((int) HttpStatusCode.OK, null)]
    [SwaggerResponse((int) HttpStatusCode.NotFound, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<GetTripResponse>> GetTrip([FromRoute] int id)
    {
        return await Mediator.Send(new GetTrip(id));
    }
}