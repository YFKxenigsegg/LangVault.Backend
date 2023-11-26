namespace Domain.Entities.Masterdata;
public class Tag : BaseEntity
{
    public string Value { get; set; } = default!;
    public string Color { get; set; } = default!;
    public int LinguisticElementType { get; set; }
    public int Priority { get; set; }
}
