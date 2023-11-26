using ConstructType = Domain.Entities.Masterdata.ConstructType;

namespace Application.Masterdata.ConstructTypes;
public class ConstructTypeInfo : IMapFrom<ConstructType>
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
