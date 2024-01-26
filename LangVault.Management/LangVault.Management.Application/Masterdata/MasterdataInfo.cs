using LangVault.Management.Application.Masterdata.ConstructTypes;
using LangVault.Management.Application.Masterdata.Tags;
using LangVault.Management.Application.Masterdata.WordTypes;

namespace Application.Masterdata;
public class MasterdataInfo
{
    public ICollection<TagInfo> Tags { get; set; } = default!;
    public ICollection<WordTypeInfo> WordTypes { get; set; } = default!;
    public ICollection<ConstructTypeInfo> ConstructTypes { get; set; } = default!;
}
