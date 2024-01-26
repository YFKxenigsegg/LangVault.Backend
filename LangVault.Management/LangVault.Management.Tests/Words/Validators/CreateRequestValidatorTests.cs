using LangVault.Management.Application.Words.Commands;

namespace LangVault.Management.Tests.Words.Validators;
public class CreateRequestValidatorTests : BaseTest
{
    [Test]
    public async Task Should_Throw_ValidationException_Value_Empty()
    {
        var request = new CreateRequest(string.Empty, WordType.Noun);

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Value_Length()
    {
        var request = new CreateRequest("word_with_more_than_twenty_symbols", WordType.Noun);

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Should_Throw_ValidationException_Be_Unique_Word()
    {
        var value = "car";
        var type = WordType.Noun;
        await SendAsync(new CreateRequest(value, type));
        var request = new CreateRequest(value, type);

        await FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
