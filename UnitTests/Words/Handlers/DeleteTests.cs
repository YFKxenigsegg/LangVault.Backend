using Application.Words.Commands;
using Domain.Entities.Base;

namespace UnitTests.Words.Handlers;
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
        var response = await SendAsync(new CreateRequest("dog", WordType.Noun));
        var request = new DeleteRequest(response.Id);
        
        await SendAsync(request);

        var result = await FindAsync<Word>(response.Id);
        result.Should().BeNull();
    }
}
