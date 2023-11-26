using Application.Common.Models;
using Application.Constructs;
using Application.Constructs.Commands;
using Application.Constructs.Queries;
using Application.Search;
using Domain.Entities.Base;

namespace LangVault.Admin.Controllers;
public class ConstructsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ConstructInfo>> Get([FromQuery] GetRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ConstructInfo>>> GetPaginated([FromQuery] GetPaginatedRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<ConstructInfo>> Create(CreateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<PaginatedList<ConstructInfo>>> Search(SearchRequest<Construct, ConstructInfo> request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<ConstructInfo>> Update(UpdateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(DeleteRequest request)
    {
        return await Mediator.Send(request);
    }
}
