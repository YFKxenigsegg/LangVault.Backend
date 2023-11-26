namespace Application.Constructs.Commands.Create;
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
            .MaximumLength(TextUtilities.MaxConstructLength).WithMessage($"\"Value\" must not exceed {TextUtilities.MaxConstructLength} characters.")
            .MustAsync(BeUniqueConstructAsync).WithMessage("The specified \"Value\" already exists.");
    }

    public async Task<bool> BeUniqueConstructAsync(string value, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Constructs
            .AllAsync(x => x.Value != value, cancellationToken);
    }
}
