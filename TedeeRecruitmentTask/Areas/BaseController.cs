using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace TedeeRecruitmentTask.Api.Areas;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
[SwaggerResponse((int) HttpStatusCode.InternalServerError, null)]
public abstract class BaseController : Controller
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}
