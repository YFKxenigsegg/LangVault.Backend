namespace LangVault.Management.Infrastructure.Configurations.Base;
public class ConstructConfiguration : LinguisticElementConfiguration<Construct>
{
    public override void Configure(EntityTypeBuilder<Construct> builder)
    {
        base.Configure(builder);

        builder.ToTable("Constructs");

        builder.Property(x => x.Value)
            .HasMaxLength(LengthConstraints.MaxConstructLength)
            .IsRequired();

        builder.Property(x => x.Type)
           .IsRequired();

        builder.HasMany(x => x.Translations)
            .WithOne()
            .IsRequired(false);

        builder.HasMany(x => x.Words)
            .WithOne()
            .HasForeignKey(x => x.ConstructId)
            .IsRequired(false);
    }
}
