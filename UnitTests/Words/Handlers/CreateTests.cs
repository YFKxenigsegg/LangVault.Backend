using Application.Words.Commands;
using Domain.Entities.Base;

namespace UnitTests.Words.Handlers;
public class CreateTests : BaseTest
{
    [Test]
    public async Task Should_Create_Word()
    {
        var request = new CreateRequest("dot", WordType.Noun);

        var response = await SendAsync(request);

        var result = await FindAsync<Word>(response.Id);
        result.Should().NotBeNull();
    }

    [Test]
    public async Task Should_Create_Value()
    {
        var expected = "lion";
        var request = new CreateRequest(expected, WordType.Noun);

        var result = await SendAsync(request);

        result.Value.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Type()
    {
        var expected = WordType.Verb;
        var request = new CreateRequest("cut", expected);

        var result = await SendAsync(request);

        result.Type.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Translations()
    {
        var expected = new List<string> { "translation" };
        var request = new CreateRequest("cut", WordType.Verb, expected);

        var result = await SendAsync(request);

        result.Translations.Should().Equal(expected);
    }
}
