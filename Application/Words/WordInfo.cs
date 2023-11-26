namespace Application.Words;
public partial class WordInfo : BaseInfo, IMapFrom<WordInfo>
{
    public string Value { get; set; } = default!;
    public WordType Type { get; set; }
    public ICollection<string> Translations { get; set; } = default!;
}
