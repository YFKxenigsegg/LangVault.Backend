namespace LangVault.Management.Application.Words.Commands;
public record CreateRequest(string Value, WordType Type, ICollection<string> Translations = default!)
    : IRequest<WordInfo>;
