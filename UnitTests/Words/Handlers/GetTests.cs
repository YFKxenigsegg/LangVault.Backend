using Application.Words.Commands;
using Application.Words.Queries;

namespace UnitTests.Words.Handlers;
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
        var response = await SendAsync(new CreateRequest("dog", WordType.Noun));
        var request = new GetRequest(response.Id);

        var result = await SendAsync(request);

        result.Should().NotBeNull();
    }
}
