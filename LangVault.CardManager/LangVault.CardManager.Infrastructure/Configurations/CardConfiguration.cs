namespace LangVault.CardManager.Infrastructure.Configurations;
public class CardConfiguration<T> : BaseAuditableEntityConfiguration<T>
    where T : Card
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        //builder.UseTpcMappingStrategy();
    }
}
