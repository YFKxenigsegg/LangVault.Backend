namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add check type construct", 0, 3, 0, 2)]
public class AddCheckTypeConstruct : Migration
{
    public override void Up()
    {
        Execute.Sql($@"
            ALTER TABLE ""Constructs""
            ADD CONSTRAINT ""CHK_Constructs_Type"" CHECK (""Type"" >= {Enum.GetValues(typeof(ConstructType)).Cast<int>().Min()} 
                AND ""Type"" <= {Enum.GetValues(typeof(ConstructType)).Cast<int>().Max()});
        ");
    }

    public override void Down()
    {
        Execute.Sql(@"
            ALTER TABLE ""Constructs""
            DROP CONSTRAINT ""CHK_Constructs_Type"";
        ");
    }
}
