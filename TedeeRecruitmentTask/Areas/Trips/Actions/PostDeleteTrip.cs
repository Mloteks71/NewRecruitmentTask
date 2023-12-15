using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Commands;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpDelete("/api/my/[controller]/{id}")]
    [SwaggerOperation(Summary = "Delete trip.")]
    [SwaggerResponse((int) HttpStatusCode.NoContent, null)]
    [SwaggerResponse((int) HttpStatusCode.NotFound, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<PostDeleteTripResponse>> PostDeleteTrip([FromRoute] int id)
    {

        return await Mediator.Send(new PostDeleteTrip(id));
    }
}