using Application.Constructs.Commands;
using Application.Constructs.Queries;

namespace UnitTests.Constructs.Handlers;
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
        var reponse = await SendAsync(new CreateRequest("go away", ConstructType.PhrasalVerb));
        var request = new GetRequest(reponse.Id);

        var result = await SendAsync(request);

        result.Should().NotBeNull();
    }
}
