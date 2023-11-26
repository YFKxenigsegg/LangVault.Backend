using Application.Words.Commands;

namespace UnitTests.Words.Handlers;
public class UpdateTests : BaseTest
{
    [Test]
    public void Should_Throw_NotFoundException()
    {
        var request = new UpdateRequest() { Id = 1, Value = "car", Type = WordType.Noun };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task Should_Update_Value()
    {
        var expected = "world";
        var type = WordType.Noun;
        var entity = await SendAsync(new CreateRequest("car", type));
        var request = new UpdateRequest() { Id = entity.Id, Value = expected, Type = type };

        var result = await SendAsync(request);

        result.Value.Should().Be(expected);
    }

    [Test]
    public async Task Should_Update_Type()
    {
        var expected = WordType.Verb;
        var value = "cut";
        var entity = await SendAsync(new CreateRequest(value, WordType.Noun));
        var request = new UpdateRequest() { Id = entity.Id, Value = value, Type = expected };

        var result = await SendAsync(request);

        result.Type.Should().Be(expected);
    }

    // Warning: check in case update only "Translations" - "Type" and "Value" are constant. (Fail validation)
    [Test]
    public async Task Should_Update_Translations()
    {
        var expected = new List<string> { "newTranslation1", "newTranslation2" };
        var value = "cut";
        var entity = await SendAsync(new CreateRequest(value, WordType.Verb, new List<string> { "translation" }));
        var request = new UpdateRequest() { Id = entity.Id, Value = value, Type = WordType.Adverb, Translations = expected };

        var result = await SendAsync(request);

        result.Translations.Should().Equal(expected);
    }
}
