namespace LangVault.Management.Infrastructure.Configurations.Masterdata;
public class TagConfiguration : BaseEntityConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Value)
            .IsRequired();

        builder.HasIndex(x => x.Value)
            .IsUnique();

        builder.Property(x => x.Color)
            .HasMaxLength(7)
            .IsRequired();

        builder.Property(x => x.Priority)
            .IsRequired();
    }
}
