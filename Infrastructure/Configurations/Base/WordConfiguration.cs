namespace Infrastructure.Configurations.Base;
public class WordConfiguration : LinguisticElementConfiguration<Word>
{
    public override void Configure(EntityTypeBuilder<Word> builder)
    {
        base.Configure(builder);

        builder.ToTable("Words");

        builder.Property(x => x.Value)
            .HasMaxLength(LengthConstraints.MaxWordLength)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.HasMany(x => x.Translations)
            .WithOne()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Construct>()
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.ConstructId)
            .IsRequired(false);

        builder.HasIndex(x => new { x.Value, x.Type })
            .IsUnique();
    }
}
