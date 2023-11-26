namespace Domain.Entities.Base;
public class Word : LinguisticElement
{
    public int? ConstructId { get; set; }
    public WordType Type { get; set; }
}
