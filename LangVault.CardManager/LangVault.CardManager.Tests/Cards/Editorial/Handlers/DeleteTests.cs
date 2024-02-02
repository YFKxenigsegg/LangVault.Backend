using LangVault.CardManager.Application.Card.Editorial.Commands;
using LangVault.CardManager.Domain.Entities;

namespace LangVault.CardManager.Tests.Cards.Editorial.Handlers;
public class DeleteTests : BaseTest
{
    [Test]
    public void Should_Throw_NotFoundException()
    {
        var request = new DeleteRequest(1);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task Should_Delete()
    {
        var response = await SendAsync(new CreateRequest("go off", Domain.Enums.EditorialType.PhrasalVerb));
        var request = new DeleteRequest(response.Id);

        await SendAsync(request);

        var result = await FindAsync<EditorialCard>(response.Id);
        result.Should().BeNull();
    }
}
