namespace LangVault.Management.Infrastructure.Configurations.Base;
public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.UseTpcMappingStrategy();

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}
