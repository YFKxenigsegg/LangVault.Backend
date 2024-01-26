using LangVault.Management.Domain.Entities.Masterdata;

namespace LangVault.Management.Application.Masterdata.Tags;
public class TagInfo : IMapFrom<Tag>
{
    public string Value { get; set; } = default!;
    public string Color { get; set; } = default!;
    public int Priority { get; set; }
}
