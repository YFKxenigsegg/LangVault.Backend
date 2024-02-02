namespace LangVault.CardManager.Infrastructure.Migrations.Migrations;
[VersionedMigration("Seed db", 0, 1, 0, 1)]
public class SeedDb : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory").IfExists();

        Create.Table("CardTypes")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_CardTypes").Identity()
            .WithColumn("Name").AsString(16).NotNullable()
            .WithColumn("Type").AsInt32().NotNullable();

        Insert.IntoTable("CardTypes").Row(new { Name = "Editorial", Type = (int)CardType.Editorial });

        Create.Table("EditorialTypes")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_EditorialTypes").Identity()
            .WithColumn("Name").AsString(16).NotNullable()
            .WithColumn("Type").AsInt32().NotNullable();

        Insert.IntoTable("EditorialTypes").Row(new { Name = "Noun", Type = (int)(int)EditorialType.Noun });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Verb", Type = (int)EditorialType.Verb });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Adjective", Type = (int)EditorialType.Adjective });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Pronoun", Type = (int)EditorialType.Pronoun });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "PhrasalVerb", Type = (int)EditorialType.PhrasalVerb });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Idiom", Type = (int)EditorialType.Idiom });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Collocation", Type = (int)EditorialType.Collocation });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Adverb", Type = (int)EditorialType.Adverb });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Preposition", Type = (int)EditorialType.Preposition });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Interjection", Type = (int)EditorialType.Interjection });
        Insert.IntoTable("EditorialTypes").Row(new { Name = "Conjunction", Type = (int)EditorialType.Conjunction });
    }

    public override void Down()
    {
        Delete.FromTable("CardTypes").AllRows();
        Delete.Table("CardTypes");

        Delete.FromTable("EditorialTypes").AllRows();
        Delete.Table("EditorialTypes");

        Execute.Sql(@"
            CREATE TABLE IF NOT EXISTS public.""__EFMigrationsHistory""
            (
                ""MigrationId"" character varying(150) COLLATE pg_catalog.""default"" NOT NULL,
                ""ProductVersion"" character varying(32) COLLATE pg_catalog.""default"" NOT NULL,
                CONSTRAINT ""PK___EFMigrationsHistory"" PRIMARY KEY (""MigrationId"")
            )
        ");
    }
}
