namespace LangVault.Management.Application.Words.Commands.Delete;
public class DeleteRequestValidator : AbstractValidator<DeleteRequest>
{
    public DeleteRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid \"Id\".");
    }
}
