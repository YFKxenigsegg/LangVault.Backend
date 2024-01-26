using LangVault.Management.Application.Constructs.Commands;

namespace LangVault.Management.Tests.Constructs.Validators;
public class DeleteRequestValidatorTests
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new DeleteRequest(0);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
