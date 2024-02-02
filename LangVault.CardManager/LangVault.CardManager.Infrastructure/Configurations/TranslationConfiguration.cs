namespace LangVault.CardManager.Infrastructure.Configurations;
public class TranslationConfiguration : BaseAuditableEntityConfiguration<Translation>
{
    public override void Configure(EntityTypeBuilder<Translation> builder)
    {
        base.Configure(builder);

        builder.ToTable("Translations");

        builder.Property(x => x.Value)
            .HasMaxLength(LengthConstraints.MaxTranslationLength)
            .IsRequired();
    }
}
