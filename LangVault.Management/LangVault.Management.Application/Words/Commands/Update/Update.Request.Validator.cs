namespace LangVault.Management.Application.Words.Commands.Update;
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
            .MaximumLength(LengthConstraints.MaxWordLength).WithMessage($"\"Value\" must not exceed {LengthConstraints.MaxWordLength} characters.")
            .MustAsync(BeUniqueWordAsync).WithMessage("The specified \"Word\" already exists.");
    }

    public async Task<bool> BeUniqueWordAsync(UpdateRequest request, string value, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return !(await dbContext.Words
            .AnyAsync(x => x.Value == value && x.Type == (int)request.Type, cancellationToken));
    }
}
