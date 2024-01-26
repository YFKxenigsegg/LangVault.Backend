namespace LangVault.Management.Application.Words.Commands;
public record DeleteRequest(int Id) : IRequest<Unit>;