using Microsoft.AspNetCore.Cors;

namespace LangVault.Admin.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors("AllowOrigin")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
