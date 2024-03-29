﻿using LangVault.CardManager.Application.Card.Editorial.Queries;

namespace LangVault.CardManager.Tests.Cards.Editorial.Validators;
public class GetPaginatedRequestValidatorTests : BaseTest
{
    [Test]
    public void Should_Throw_ValidationException_PageSize()
    {
        var request = new GetPaginatedRequest(PageSize: -1);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public void Should_Throw_ValidationException_PageNumber()
    {
        var request = new GetPaginatedRequest(PageNumber: -1);

        FluentActions.Invoking(async () => await SendAsync(request)).Should().ThrowAsync<ValidationException>();
    }
}
