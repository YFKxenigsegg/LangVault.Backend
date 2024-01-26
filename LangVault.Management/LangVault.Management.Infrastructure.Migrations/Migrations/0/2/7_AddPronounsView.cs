namespace LangVault.Management.Infrastructure.Migrations;
[VersionedMigration("Add Pronouns view", 0, 2, 0, 7)]
public class AddPronounsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Pronouns.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Pronouns.sql");
    }
}
