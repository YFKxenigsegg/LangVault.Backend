namespace LangVault.Management.Infrastructure.Migrations;
[VersionedMigration("Add Idioms view", 0, 2, 0, 10)]
public class AddIdiomsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Idioms.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Idioms.sql");
    }
}
