using LangVault.Management.Application.Constructs.Queries;

namespace LangVault.Management.Tests.Constructs.Validators;
public class GetRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new GetRequest(0);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
