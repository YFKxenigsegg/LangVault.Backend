using LangVault.CardManager.Application.Card.Editorial.Commands;

namespace LangVault.CardManager.Tests.Cards.Editorial.Handlers;
public class UpdateTests : BaseTest
{
    [Test]
    public void Should_Throw_NotFoundException()
    {
        var request = new UpdateRequest() { Id = 1, Value = "jump at the chance", Type = EditorialType.Collocation };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task Should_Update_Value()
    {
        var expected = "break out";
        var type = EditorialType.PhrasalVerb;
        var entity = await SendAsync(new CreateRequest("move forward", type));
        var request = new UpdateRequest() { Id = entity.Id, Value = expected, Type = type };

        var response = await SendAsync(request);

        response.Value.Should().Be(expected);
    }

    // Warning: check in case update only "Type". (Fail validation)
    [Test]
    public async Task Should_Update_Type_And_Value()
    {
        var expected = EditorialType.Idiom;
        var value = "on the road";
        var entity = await SendAsync(new CreateRequest(value, EditorialType.Collocation));
        var request = new UpdateRequest() { Id = entity.Id, Value = "lo and behold", Type = expected };

        var response = await SendAsync(request);

        response.Type.Should().Be(expected);
    }

    // Warning: check in case update only "Translations" - "Type" and "Value" are constant (Fail validation)
    [Test]
    public async Task Should_Update_Translations()
    {
        var expected = new List<string> { "newTranslation1", "newTranslation2" };
        var entity = await SendAsync(new CreateRequest("move forward", EditorialType.PhrasalVerb, new List<string> { "translation" }));
        var request = new UpdateRequest() { Id = entity.Id, Value = "look after", Type = EditorialType.Idiom, Translations = expected };

        var response = await SendAsync(request);

        response.Translations.Should().Equal(expected);
    }
}
