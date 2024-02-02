namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory;

    public UpdateRequestValidator(IDbContextFactory<CardManagerDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;

        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid \"Type\".");

        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("\"Value\" is required.")
            .MaximumLength(LengthConstraints.MaxValueLength).WithMessage($"\"Value\" must not exceed {LengthConstraints.MaxValueLength} characters.")
            .MustAsync(BeUniqueConstructAsync).WithMessage("The specified \"Value\" already exists.");
    }

    public async Task<bool> BeUniqueConstructAsync(string value, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.EditorialCards
            .AllAsync(x => x.Value != value, cancellationToken);
    }
}
