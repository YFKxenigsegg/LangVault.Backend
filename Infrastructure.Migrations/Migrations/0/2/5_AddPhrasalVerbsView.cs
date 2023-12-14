namespace Infrastructure.Migrations;
[VersionedMigration("Add PhrasalVerbs view", 0, 2, 0, 5)]
public class AddPhrasalVerbsView : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Views.PhrasalVerbs.sql");
    }

    public override void Down()
    {
        Execute.EmbeddedScript("Infrastructure.Migrations.Scripts.Drops.PhrasalVerbs.sql");
    }
}
