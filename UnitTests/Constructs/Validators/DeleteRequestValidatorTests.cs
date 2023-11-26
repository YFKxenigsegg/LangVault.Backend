using Application.Constructs.Commands;

namespace UnitTests.Constructs.Validators;
public class DeleteRequestValidatorTests
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new DeleteRequest(0);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
