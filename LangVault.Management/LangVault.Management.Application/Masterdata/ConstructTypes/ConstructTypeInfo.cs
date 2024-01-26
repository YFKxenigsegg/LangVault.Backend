using ConstructType = LangVault.Management.Domain.Entities.Masterdata.ConstructType;

namespace LangVault.Management.Application.Masterdata.ConstructTypes;
public class ConstructTypeInfo : IMapFrom<ConstructType>
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
