using LangVault.CardManager.Application.Card.Editorial.Commands;
using LangVault.CardManager.Application.Card.Editorial.Queries;

namespace LangVault.CardManager.Tests.Cards.Editorial.Handlers;
public class GetTests : BaseTest
{
    [Test]
    public void Should_Throw_NotFoundException()
    {
        var request = new GetRequest(1);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task Should_Get_Word()
    {
        var reponse = await SendAsync(new CreateRequest("go away", EditorialType.PhrasalVerb));
        var request = new GetRequest(reponse.Id);

        var result = await SendAsync(request);

        result.Should().NotBeNull();
    }
}
