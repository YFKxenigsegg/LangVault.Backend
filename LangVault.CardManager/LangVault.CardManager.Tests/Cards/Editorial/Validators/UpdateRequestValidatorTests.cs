using LangVault.CardManager.Application.Card.Editorial.Commands;

namespace LangVault.CardManager.Tests.Cards.Editorial.Validators;
public class UpdateRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new UpdateRequest { Id = 0, Value = "watch out", Type = EditorialType.PhrasalVerb };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Empty()
    {
        var request = new UpdateRequest() { Id = 1, Value = string.Empty, Type = EditorialType.Idiom };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Length()
    {
        var request = new UpdateRequest() { Id = 1, Value = "construct_with_more_than_(32)_symbols", Type = EditorialType.Idiom };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Unique_Construct()
    {
        var value = "jump at the chance";
        await SendAsync(new CreateRequest(value, EditorialType.Collocation));
        var entity = await SendAsync(new CreateRequest("bring down", EditorialType.PhrasalVerb));
        var request = new UpdateRequest() { Id = entity.Id, Value = value, Type = EditorialType.PhrasalVerb };

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
