namespace LangVault.Management.Infrastructure.Migrations;
[VersionedMigration("Add Nouns view", 0, 2, 0, 6)]
public class AddNounsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Nouns.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Nouns.sql");
    }
}
