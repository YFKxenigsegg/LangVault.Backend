namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add Collocations view", 0, 2, 0, 11)]
public class AddCollocationssView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.Collocations.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.Collocations.sql");
    }
}
