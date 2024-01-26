using LangVault.Management.Application.Common.Models;
using LangVault.Management.Application.Constructs;
using LangVault.Management.Application.Constructs.Commands;
using LangVault.Management.Application.Constructs.Queries;
using LangVault.Management.Application.Search;
using LangVault.Management.Domain.Entities.Base;

namespace LangVault.Management.Controllers;
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
