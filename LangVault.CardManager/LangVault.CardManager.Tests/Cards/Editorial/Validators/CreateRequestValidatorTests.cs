using LangVault.CardManager.Application.Card.Editorial.Commands;

namespace LangVault.CardManager.Tests.Cards.Editorial.Validators;
public class CreateRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Value_Empty()
    {
        var request = new CreateRequest(string.Empty, EditorialType.Collocation);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Length()
    {
        var request = new CreateRequest("construct_with_more_than_(32)_symbols", EditorialType.Collocation);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Unique_Construct()
    {
        var value = "move forward";
        await SendAsync(new CreateRequest(value, EditorialType.PhrasalVerb));
        var request = new CreateRequest(value, EditorialType.Idiom);

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
