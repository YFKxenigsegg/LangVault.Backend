namespace Infrastructure.Migrations;
[VersionedMigration("Add Prepositions view", 0, 2, 0, 2)]
public class AddPrepositionsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Prepositions.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Prepositions.sql");
    }
}
