namespace Application.Constructs.Commands.Update;
public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public UpdateRequestValidator(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;

        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid \"Type\".");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("\"Value\" is required.")
            .MaximumLength(LengthConstraints.MaxConstructLength).WithMessage($"\"Value\" must not exceed {LengthConstraints.MaxConstructLength} characters.")
            .MustAsync(BeUniqueConstructAsync).WithMessage("The specified \"Value\" already exists.");
    }

    public async Task<bool> BeUniqueConstructAsync(string value, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Constructs
            .AllAsync(x => x.Value != value, cancellationToken);
    }
}
