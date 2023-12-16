namespace Domain.Entities.Base;
public class Construct : LinguisticElement
{
    public ICollection<Word> Words { get; } = default!;
}
