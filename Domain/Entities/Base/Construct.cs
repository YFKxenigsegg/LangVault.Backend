namespace Domain.Entities.Base;
public class Construct : LinguisticElement
{
    public ConstructType Type { get; set; }
    public ICollection<Word> Words { get; } = default!;
}
