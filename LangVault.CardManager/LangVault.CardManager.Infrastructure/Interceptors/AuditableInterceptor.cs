using LangVault.CardManager.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LangVault.CardManager.Infrastructure.Interceptors;
public sealed class AuditableInterceptor(ICurrentUserProvider currentUserProvider) : SaveChangesInterceptor
{
    private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateAuditableEntities(DbContext context)
    {
        var utcNow = DateTime.UtcNow;
        var userId = _currentUserProvider.UserId;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(BaseAuditableEntity.CreatedBy)).CurrentValue = userId;
                entry.Property(nameof(BaseAuditableEntity.CreatedUtc)).CurrentValue = utcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Property(nameof(BaseAuditableEntity.ModifiedUtc)).CurrentValue = utcNow;
            }
        }
    }
}
