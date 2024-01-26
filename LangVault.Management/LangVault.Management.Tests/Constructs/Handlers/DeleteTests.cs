using LangVault.Management.Application.Constructs.Commands;
using LangVault.Management.Domain.Entities.Base;

namespace LangVault.Management.Tests.Constructs.Handlers;
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
