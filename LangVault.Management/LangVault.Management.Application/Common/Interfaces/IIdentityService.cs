namespace LangVault.Management.Application.Common.Interfaces;
public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);
}
