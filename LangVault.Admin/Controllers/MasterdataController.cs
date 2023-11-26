using Application.Masterdata;
using Application.Masterdata.Queries;

namespace LangVault.Admin.Controllers;
public class MasterdataController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<MasterdataInfo>> Get()
    {
        return Ok(await Mediator.Send(new GetRequest()));
    }
}
