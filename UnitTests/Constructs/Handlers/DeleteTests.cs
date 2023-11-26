using Application.Constructs.Commands;
using Domain.Entities.Base;

namespace UnitTests.Constructs.Handlers;
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
        var response = await SendAsync(new CreateRequest("go off", ConstructType.PhrasalVerb));
        var request = new DeleteRequest(response.Id);

        await SendAsync(request);

        var result = await FindAsync<Construct>(response.Id);
        result.Should().BeNull();
    }
}
