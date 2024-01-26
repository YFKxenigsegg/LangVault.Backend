namespace LangVault.Management.Domain.Entities.Masterdata;
public class WordType : BaseEntity
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
