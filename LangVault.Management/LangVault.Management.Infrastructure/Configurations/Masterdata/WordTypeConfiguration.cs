namespace LangVault.Management.Infrastructure.Configurations.Masterdata;
public class WordTypeConfiguration : BaseEntityConfiguration<WordType>
{
    public override void Configure(EntityTypeBuilder<WordType> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .HasMaxLength(16)
            .IsRequired();

        builder.Property(x => x.Value)
            .IsRequired();
    }
}
