namespace LangVault.CardManager.Infrastructure.Migrations;
[VersionedMigration("Add Adjectives view", 0, 2, 0, 8)]
public class AddAdjectivesView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Adjectives.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Adjectives.sql");
    }
}
