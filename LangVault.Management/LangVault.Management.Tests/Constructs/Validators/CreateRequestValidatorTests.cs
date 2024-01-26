using LangVault.Management.Application.Constructs.Commands;

namespace LangVault.Management.Tests.Constructs.Validators;
public class CreateRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Value_Empty()
    {
        var request = new CreateRequest(string.Empty, ConstructType.Collocation);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Length()
    {
        var request = new CreateRequest("construct_with_more_than_(32)_symbols", ConstructType.Collocation);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Unique_Construct()
    {
        var value = "move forward";
        await SendAsync(new CreateRequest(value, ConstructType.PhrasalVerb));
        var request = new CreateRequest(value, ConstructType.Idiom);

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
