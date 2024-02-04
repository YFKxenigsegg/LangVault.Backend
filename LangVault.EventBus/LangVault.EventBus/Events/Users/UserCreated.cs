namespace LangVault.EventBus.Events.Users;
public class UserCreated
{
    public string UserName { get; set; } = default!;
    public int UsertId { get; set; }
}
