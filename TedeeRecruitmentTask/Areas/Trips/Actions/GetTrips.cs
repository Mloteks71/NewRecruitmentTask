using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpGet("/api/my/[controller]")]
    [SwaggerOperation(Summary = "Get trips.")]
    [SwaggerResponse((int) HttpStatusCode.OK, null)]
    [SwaggerResponse((int) HttpStatusCode.NotFound, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<GetTripsResponse>> GetTrips()
    {

        return await Mediator.Send(new GetTrips());
    }
}