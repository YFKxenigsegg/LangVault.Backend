namespace LangVault.Management.Infrastructure;
public static class InitialData
{
    public static List<WordType> WordTypes { get; }
    public static List<ConstructType> ConstructTypes { get; }
    public static List<Tag> Tags { get; }

    static InitialData()
    {
        WordTypes =
            [
                new() { Name = "Noun", Value = (int)Domain.Enums.WordType.Noun },
                new() { Name = "Pronoun", Value = (int)Domain.Enums.WordType.Pronoun },
                new() { Name = "Adjective", Value = (int)Domain.Enums.WordType.Adjective },
                new() { Name = "Verb", Value = (int)Domain.Enums.WordType.Verb },
                new() { Name = "Adverb", Value = (int)Domain.Enums.WordType.Adverb },
                new() { Name = "Preposition", Value = (int)Domain.Enums.WordType.Preposition },
                new() { Name = "Conjunction", Value = (int)Domain.Enums.WordType.Conjunction },
                new() { Name = "Interjection", Value = (int)Domain.Enums.WordType.Interjection }
            ];
        ConstructTypes =
            [
                new() { Name = "Phrasal Verb", Value = (int)Domain.Enums.ConstructType.PhrasalVerb },
                new() { Name = "Idiom", Value = (int)Domain.Enums.ConstructType.Idiom },
                new() { Name = "Collocation", Value = (int)Domain.Enums.ConstructType.Collocation }
            ];
        Tags =
            [
                new() { Value = "Noun", Color = "#8A2BE2", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 0 },
                new() { Value = "Pronoun", Color = "#DC143C", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 1 },
                new() { Value = "Adjective", Color = "#FF8C00", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 2 },
                new() { Value = "Verb", Color = "#32CD32", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 3 },
                new() { Value = "Adverb", Color = "#FFD700", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 4 },
                new() { Value = "Preposition", Color = "#8B008B", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 5 },
                new() { Value = "Conjunction", Color = "#B22222", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 6 },
                new() { Value = "Interjection", Color = "#20B2AA", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Word, Priority = 7 },
                new() { Value = "Phrasal Verb", Color = "#FF69B4", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Construct, Priority = 8 },
                new() { Value = "Idiom", Color = "#483D8B", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Construct, Priority = 9 },
                new() { Value = "Collocation", Color = "#6A5ACD", LinguisticElementType = (int)Domain.Enums.LinguisticElementType.Construct, Priority = 10 },
            ];
    }
}
