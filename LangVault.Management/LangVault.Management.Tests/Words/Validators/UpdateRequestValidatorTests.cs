using LangVault.Management.Application.Words.Commands;

namespace LangVault.Management.Tests.Words.Validators;
public class UpdateRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_Id()
    {
        var request = new UpdateRequest { Id = 0, Value = "dog", Type = WordType.Noun };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Empty()
    {
        var request = new UpdateRequest() { Id = 1, Value = string.Empty, Type = WordType.Adjective };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_Value_Length()
    {
        var request = new UpdateRequest() { Id = 1, Value = "word_with_more_than_twenty_symbols", Type = WordType.Adjective };

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Unique_Word()
    {
        var value = "car";
        var type = WordType.Noun;
        await SendAsync(new CreateRequest(value, type));
        var entity = await SendAsync(new CreateRequest("world", type));
        var request = new UpdateRequest() { Id = entity.Id, Value = value, Type = type };

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
