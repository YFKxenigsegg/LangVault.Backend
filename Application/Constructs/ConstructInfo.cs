namespace Application.Constructs;
public partial class ConstructInfo : BaseInfo, IMapFrom<ConstructInfo>
{
    public string Value { get; set; } = default!;
    public ConstructType Type { get; set; }
    public ICollection<string> Translations { get; set; } = default!;
}
