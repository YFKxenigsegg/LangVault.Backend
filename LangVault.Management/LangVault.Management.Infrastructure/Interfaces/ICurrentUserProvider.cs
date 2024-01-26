namespace LangVault.Management.Infrastructure.Interfaces;
public interface ICurrentUserProvider
{
    string? UserId { get; }
}
