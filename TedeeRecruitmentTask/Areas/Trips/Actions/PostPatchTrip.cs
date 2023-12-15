using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Commands;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpPatch("/api/my/[controller]/{id}")]
    [SwaggerOperation(Summary = "Patch trip.")]
    [SwaggerResponse((int) HttpStatusCode.OK, null)]
    [SwaggerResponse((int) HttpStatusCode.NotFound, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<PostPatchTripResponse>> PostPatchTrip([FromRoute] int id, [FromBody] PostPatchTripRequest body)
    {

        return await Mediator.Send(new PostPatchTrip(body, id));
    }
}