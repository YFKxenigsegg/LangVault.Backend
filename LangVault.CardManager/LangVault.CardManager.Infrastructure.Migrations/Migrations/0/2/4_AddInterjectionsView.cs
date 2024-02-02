namespace LangVault.CardManager.Infrastructure.Migrations;
[VersionedMigration("Add Interjections view", 0, 2, 0, 4)]
public class AddInterjectionsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Interjections.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Interjections.sql");
    }
}
