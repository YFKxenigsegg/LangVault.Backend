namespace Infrastructure.Configurations.Base;
public class TranslationConfiguration : BaseAuditableEntityConfiguration<Translation>
{
    public override void Configure(EntityTypeBuilder<Translation> builder)
    {
        base.Configure(builder);

        builder.ToTable("Translations");

        builder.Property(x => x.Value)
            .HasMaxLength(64)
            .IsRequired();
    }
}
