namespace Application.Constructs.Queries.GetPaginated;
public class GetPaginatedRequestValidator : AbstractValidator<GetPaginatedRequest>
{
    public GetPaginatedRequestValidator()
    {
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Invalid \"PageSize\".");
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Invalid \"PageNumber\".");
    }
}
