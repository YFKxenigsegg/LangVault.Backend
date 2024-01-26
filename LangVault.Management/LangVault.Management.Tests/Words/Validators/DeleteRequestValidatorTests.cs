using LangVault.Management.Application.Words.Commands;

namespace LangVault.Management.Tests.Words.Validators;
public class DeleteRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new DeleteRequest(0);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
