namespace LangVault.Management.Application.Constructs.Commands;
public record CreateRequest(string Value, ConstructType Type, ICollection<string> Translations = default!)
    : IRequest<ConstructInfo>;
