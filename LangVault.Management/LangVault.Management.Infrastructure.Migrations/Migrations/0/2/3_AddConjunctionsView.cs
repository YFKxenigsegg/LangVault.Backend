namespace LangVault.Management.Infrastructure.Migrations;
[VersionedMigration("Add Conjunctions view", 0, 2, 0, 3)]
public class AddConjunctionsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Conjunctions.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Conjunctions.sql");
    }
}
