namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public class DeleteRequestValidator : AbstractValidator<DeleteRequest>
{
    public DeleteRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");
    }
}
