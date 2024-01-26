using LangVault.Management.Application.Words.Commands;
using LangVault.Management.Application.Common.Models;
using LangVault.Management.Application.Search;
using LangVault.Management.Application.Words;
using LangVault.Management.Application.Words.Queries;
using LangVault.Management.Domain.Entities.Base;

namespace LangVault.Management.Controllers;
public class WordsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<WordInfo>> Get([FromQuery] GetRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<WordInfo>>> GetPaginated([FromQuery] GetPaginatedRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<WordInfo>> Create(CreateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<PaginatedList<WordInfo>>> Search(SearchRequest<Word, WordInfo> request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<WordInfo>> Update(UpdateRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(DeleteRequest request)
    {
        return await Mediator.Send(request);
    }
}
