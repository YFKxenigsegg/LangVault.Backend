using LangVault.CardManager.Domain.Entities;

namespace LangVault.CardManager.Infrastructure.Configurations;
public class EditorialCardConfiguration : CardConfiguration<EditorialCard>
{
    public override void Configure(EntityTypeBuilder<EditorialCard> builder)
    {
        base.Configure(builder);

        builder.ToTable("EditorialCards");

        builder.Property(x => x.Value)
            .HasMaxLength(LengthConstraints.MaxValueLength)
            .IsRequired();

        builder.Property(x => x.Type)
           .IsRequired();

        builder.HasMany(x => x.Translations)
            .WithOne()
            .IsRequired(false);
    }
}
