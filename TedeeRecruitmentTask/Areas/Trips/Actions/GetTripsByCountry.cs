using Microsoft.AspNetCore.Mvc;
using TedeeRecruitmentTask.Application.Areas.Trips.Models.Responses;
using TedeeRecruitmentTask.Application.Areas.Trips.Queriess;
using TedeeRecruitmentTask.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas.Trips.Actions;

public partial class TripController : BaseController
{
    [HttpGet("/api/my/[controller]/byCountry/{country}")]
    [SwaggerOperation(Summary = "Get trips by country.")]
    [SwaggerResponse((int) HttpStatusCode.OK, null)]
    [SwaggerResponse((int) HttpStatusCode.NotFound, null)]
    [SwaggerResponse((int) HttpStatusCode.BadRequest, null)]
    public async Task<ActionResult<GetTripsByCountryResponse>> PostPatchTrip([FromRoute] Country country)
    {
        return await Mediator.Send(new GetTripsByCountry(country));
    }
}