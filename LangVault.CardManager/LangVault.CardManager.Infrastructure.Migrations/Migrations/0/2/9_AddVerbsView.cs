namespace LangVault.CardManager.Infrastructure.Migrations;
[VersionedMigration("Add Verbs view", 0, 2, 0, 9)]
public class AddVerbsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Verbs.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Verbs.sql");
    }
}
