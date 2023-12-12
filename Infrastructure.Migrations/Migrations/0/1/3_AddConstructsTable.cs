namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add Constructs table", 0, 1, 0, 3)]
public class AddConstructsTable : Migration
{
    public override void Up()
    {
        Create.Table("Constructs")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_Constructs").Identity()
            .WithColumn("Type").AsInt32().NotNullable()
            .WithColumn("CreatedBy").AsFixedLengthString(16).Nullable()
            .WithColumn("CreatedUtc").AsDateTimeOffset().NotNullable()
            .WithColumn("ModifiedUtc").AsDateTimeOffset().Nullable()
            .WithColumn("Value").AsFixedLengthString(32).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Constructs");
    }
}
