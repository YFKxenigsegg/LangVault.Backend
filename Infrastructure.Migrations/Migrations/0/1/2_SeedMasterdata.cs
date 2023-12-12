namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Seed masterdata tables", 0, 1, 0, 2)]
public class SeedMasterdata : Migration
{
    public override void Up()
    {
        Insert.IntoTable("WordTypes").Row(new { Name = "Noun", Value = (int)WordType.Noun });
        Insert.IntoTable("WordTypes").Row(new { Name = "Pronoun", Value = (int)WordType.Pronoun });
        Insert.IntoTable("WordTypes").Row(new { Name = "Adjective", Value = (int)WordType.Adjective });
        Insert.IntoTable("WordTypes").Row(new { Name = "Verb", Value = (int)WordType.Verb });
        Insert.IntoTable("WordTypes").Row(new { Name = "Adverb", Value = (int)WordType.Adverb });
        Insert.IntoTable("WordTypes").Row(new { Name = "Preposition", Value = (int)WordType.Preposition });
        Insert.IntoTable("WordTypes").Row(new { Name = "Conjunction", Value = (int)WordType.Conjunction });
        Insert.IntoTable("WordTypes").Row(new { Name = "Interjection", Value = (int)WordType.Interjection });

        Insert.IntoTable("ConstructTypes").Row(new { Name = "Phrasal Verb", Value = (int)ConstructType.PhrasalVerb });
        Insert.IntoTable("ConstructTypes").Row(new { Name = "Idiom", Value = (int)ConstructType.Idiom });
        Insert.IntoTable("ConstructTypes").Row(new { Name = "Collocation", Value = (int)ConstructType.Collocation });

        Insert.IntoTable("Tags").Row(new { Value = "Noun", Color = "#8A2BE2", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 0 });
        Insert.IntoTable("Tags").Row(new { Value = "Pronoun", Color = "#DC143C", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 1 });
        Insert.IntoTable("Tags").Row(new { Value = "Adjective", Color = "#FF8C00", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 2 });
        Insert.IntoTable("Tags").Row(new { Value = "Verb", Color = "#32CD32", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 3 });
        Insert.IntoTable("Tags").Row(new { Value = "Adverb", Color = "#FFD700", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 4 });
        Insert.IntoTable("Tags").Row(new { Value = "Preposition", Color = "#8B008B", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 5 });
        Insert.IntoTable("Tags").Row(new { Value = "Conjunction", Color = "#B22222", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 6 });
        Insert.IntoTable("Tags").Row(new { Value = "Interjection", Color = "#20B2AA", LinguisticElementType = (int)LinguisticElementType.Word, Priority = 7 });
        Insert.IntoTable("Tags").Row(new { Value = "Phrasal Verb", Color = "#FF69B4", LinguisticElementType = (int)LinguisticElementType.Construct, Priority = 8 });
        Insert.IntoTable("Tags").Row(new { Value = "Idiom", Color = "#483D8B", LinguisticElementType = (int)LinguisticElementType.Construct, Priority = 9 });
        Insert.IntoTable("Tags").Row(new { Value = "Collocation", Color = "#6A5ACD", LinguisticElementType = (int)LinguisticElementType.Construct, Priority = 10 });
    }

    public override void Down()
    {
        Delete.FromTable("Tags").AllRows();
        Delete.FromTable("ConstructTypes").AllRows();
        Delete.FromTable("WordTypes").AllRows();
    }
}
