using Application.Constructs.Commands;
using Domain.Entities.Base;

namespace UnitTests.Constructs.Handlers;
public class CreateTests : BaseTest
{
    [Test]
    public async Task Should_Create_Word()
    {
        var request = new CreateRequest("go away", ConstructType.PhrasalVerb);

        var response = await SendAsync(request);

        var result = await FindAsync<Construct>(response.Id);
        result.Should().NotBeNull();
    }

    [Test]
    public async Task Should_Create_Value()
    {
        var expected = "wake up";
        var request = new CreateRequest(expected, ConstructType.PhrasalVerb);

        var result = await SendAsync(request);

        result.Value.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Type()
    {
        var expected = ConstructType.PhrasalVerb;
        var request = new CreateRequest("think over", expected);

        var result = await SendAsync(request);

        result.Type.Should().Be(expected);
    }

    [Test]
    public async Task Should_Create_Translations()
    {
        var expected = new List<string> { "translation" };
        var request = new CreateRequest("think over", ConstructType.PhrasalVerb, expected);

        var result = await SendAsync(request);

        result.Translations.Should().Equal(expected);
    }
}
