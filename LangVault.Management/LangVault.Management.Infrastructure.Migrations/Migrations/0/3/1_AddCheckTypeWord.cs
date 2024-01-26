namespace LangVault.Management.Infrastructure.Migrations.Migrations;
[VersionedMigration("Add check type word", 0, 3, 0, 1)]
public class AddCheckTypeWord : Migration
{
    public override void Up()
    {
        Execute.Sql($@"
            ALTER TABLE ""Words""
            ADD CONSTRAINT ""CHK_Words_Type"" CHECK (""Type"" >= {Enum.GetValues(typeof(WordType)).Cast<int>().Min()} 
                AND ""Type"" <= {Enum.GetValues(typeof(WordType)).Cast<int>().Max()});
        ");
    }

    public override void Down()
    {
        Execute.Sql(@"
            ALTER TABLE ""Words""
            DROP CONSTRAINT ""CHK_Words_Type"";
        ");
    }
}
