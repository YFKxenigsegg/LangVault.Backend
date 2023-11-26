namespace Domain.Entities.Masterdata;
public class ConstructType : BaseEntity
{
    public string Name { get; set; } = default!;
    public int Value { get; set; }
}
