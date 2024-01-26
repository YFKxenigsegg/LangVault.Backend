namespace LangVault.Management.Application.Constructs.Queries.Get;
public class GetRequestValidator : AbstractValidator<GetRequest>
{
    public GetRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");
    }
}
