namespace LangVault.Management.Application.Words.Commands.Create;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public CreateRequestValidator(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid \"Type\".");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("\"Value\" is required.")
            .MaximumLength(LengthConstraints.MaxWordLength).WithMessage($"\"Value\" must not exceed {LengthConstraints.MaxWordLength} characters.")
            .MustAsync(BeUniqueWordAsync).WithMessage("The specified \"Value\" already exists.");
    }

    public async Task<bool> BeUniqueWordAsync(CreateRequest request, string value, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return !(await dbContext.Words
            .AnyAsync(x => x.Value == value && x.Type == (int)request.Type, cancellationToken));
    }
}
