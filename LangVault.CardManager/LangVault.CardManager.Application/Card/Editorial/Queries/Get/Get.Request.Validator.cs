namespace LangVault.CardManager.Application.Card.Editorial.Queries;
public class GetRequestValidator : AbstractValidator<GetRequest>
{
    public GetRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");
    }
}
