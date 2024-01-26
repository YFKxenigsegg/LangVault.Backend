namespace LangVault.Management.Application.Constructs.Commands;
public record DeleteRequest(int Id) : IRequest<Unit>;