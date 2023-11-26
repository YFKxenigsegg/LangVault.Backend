namespace Infrastructure.Configurations.Base;
public class BaseAuditableEntityConfiguration<T> : BaseEntityConfiguration<T>
    where T : BaseAuditableEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.UseTpcMappingStrategy();

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(16)
            .IsRequired(false);

        builder.Property(x => x.CreatedUtc)
            .IsRequired();

        builder.Property(x => x.ModifiedUtc)
            .IsRequired(false);
    }
}
