using WordType = LangVault.Management.Domain.Entities.Masterdata.WordType;

namespace LangVault.Management.Application.Masterdata.WordTypes;
public class WordTypeInfo : IMapFrom<WordType>
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
