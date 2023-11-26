namespace Infrastructure.Configurations.Base;
public class LinguisticElementConfiguration<T> : BaseAuditableEntityConfiguration<T>
    where T : LinguisticElement
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.UseTpcMappingStrategy();
    }
}
