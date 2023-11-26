using WordType = Domain.Entities.Masterdata.WordType;

namespace Application.Masterdata.WordTypes;
public class WordTypeInfo : IMapFrom<WordType>
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
