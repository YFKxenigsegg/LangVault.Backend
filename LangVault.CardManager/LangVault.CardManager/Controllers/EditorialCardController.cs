using LangVault.CardManager.Application.Card.Editorial;
using LangVault.CardManager.Application.Card.Editorial.Commands;
using LangVault.CardManager.Application.Card.Editorial.Queries;
using LangVault.CardManager.Application.Common.Models;
using LangVault.CardManager.Application.Search;
using LangVault.CardManager.Domain.Entities;

namespace LangVault.CardManager.Controllers;
public class EditorialCardController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<EditorialCardInfo>> Get([FromQuery] GetRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<EditorialCardInfo>>> GetPaginated([FromQuery] GetPaginatedRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<EditorialCardInfo>> Create(CreateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<PaginatedList<EditorialCardInfo>>> Search(SearchRequest<EditorialCard, EditorialCardInfo> request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<EditorialCardInfo>> Update(UpdateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(DeleteRequest request)
    {
        return await Mediator.Send(request);
    }
}
