using LangVault.Management.Application.Constructs.Commands;

namespace LangVault.Management.Tests.Constructs.Validators;
public class UpdateRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new UpdateRequest { Id = 0, Value = "watch out", Type = ConstructType.PhrasalVerb };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Empty()
    {
        var request = new UpdateRequest() { Id = 1, Value = string.Empty, Type = ConstructType.Idiom };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Length()
    {
        var request = new UpdateRequest() { Id = 1, Value = "construct_with_more_than_(32)_symbols", Type = ConstructType.Idiom };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Unique_Construct()
    {
        var value = "jump at the chance";
        await SendAsync(new CreateRequest(value, ConstructType.Collocation));
        var entity = await SendAsync(new CreateRequest("bring down", ConstructType.PhrasalVerb));
        var request = new UpdateRequest() { Id = entity.Id, Value = value, Type = ConstructType.PhrasalVerb };

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
