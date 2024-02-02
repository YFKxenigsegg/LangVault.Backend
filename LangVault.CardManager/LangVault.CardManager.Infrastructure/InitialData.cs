using LangVault.CardManager.Domain.Entities;

namespace LangVault.CardManager.Infrastructure;
public static class InitialData
{
    public static List<CardType> CardTypes { get; }

    static InitialData()
    {
        CardTypes =
            [
                new() { Name = "Editorial", Type = Domain.Enums.CardType.Editorial }
            ];
    }
}
