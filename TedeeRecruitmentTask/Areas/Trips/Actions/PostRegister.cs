using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Commands;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Requests;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpPost("/api/my/[controller]/{id}/register")]
    [SwaggerOperation(Summary = "Register email for trip.")]
    [SwaggerResponse((int) HttpStatusCode.Created, null)]
    [SwaggerResponse((int) HttpStatusCode.Conflict, null)]
    public async Task<ActionResult<PostRegisterResponse>> PostRegister([FromRoute] int id, [FromBody] PostRegisterRequest body)
    {
        return await Mediator.Send(new PostRegister(body, id));
    }
}
