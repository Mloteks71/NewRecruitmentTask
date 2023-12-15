using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Commands;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpPost("/api/my/[controller]")]
    [SwaggerOperation(Summary = "Create trip.")]
    [SwaggerResponse((int) HttpStatusCode.Created, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<PostAddTripResponse>> PostAddTrip([FromBody] PostAddTripRequest body)
    {
        return await Mediator.Send(new PostAddTrip(body));
    }
}