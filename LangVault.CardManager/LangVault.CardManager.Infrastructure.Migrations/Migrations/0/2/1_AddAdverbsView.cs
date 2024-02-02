namespace LangVault.CardManager.Infrastructure.Migrations;
[VersionedMigration("Add Adverbs view", 0, 2, 0, 1)]
public class AddAdverbsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Adverbs.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Adverbs.sql");
    }
}
