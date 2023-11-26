namespace Infrastructure.Interfaces;
public interface ICurrentUserProvider
{
    string? UserId { get; }
}
