using LangVault.CardManager.Application.Card.Editorial.Commands;
using LangVault.CardManager.Domain.Entities;

namespace LangVault.CardManager.Tests.Cards.Editorial.Handlers;
public class CreateTests : BaseTest
{
    [Test]
    public async Task Should_Create_Word()
    {
        var request = new CreateRequest("go away", Domain.Enums.EditorialType.PhrasalVerb);

        var response = await SendAsync(request);

        var result = await FindAsync<EditorialCard>(response.Id);
        result.Should().NotBeNull();
    }

    [Test]
    public async Task Should_Create_Value()
    {
        var expected = "wake up";
        var request = new CreateRequest(expected, Domain.Enums.EditorialType.PhrasalVerb);

        var result = await SendAsync(request);

        result.Value.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Type()
    {
        var expected = Domain.Enums.EditorialType.PhrasalVerb;
        var request = new CreateRequest("think over", expected);

        var result = await SendAsync(request);

        result.Type.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Translations()
    {
        var expected = new List<string> { "translation" };
        var request = new CreateRequest("think over", Domain.Enums.EditorialType.PhrasalVerb, expected);

        var result = await SendAsync(request);

        result.Translations.Should().Equal(expected);
    }
}
