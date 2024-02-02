namespace LangVault.CardManager.Infrastructure.Migrations.Migrations;
[VersionedMigration("Add EditorialCards table", 0, 1, 0, 2)]
public class AddEditorialCardsTable : Migration
{
    public override void Up()
    {
        Create.Table("EditorialCards")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_EditorialCards").Identity()
            .WithColumn("Type").AsInt32().NotNullable()
            .WithColumn("CreatedBy").AsString(16).Nullable()
            .WithColumn("CreatedUtc").AsDateTimeOffset().NotNullable()
            .WithColumn("ModifiedUtc").AsDateTimeOffset().Nullable()
            .WithColumn("Value").AsString(32).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("EditorialCards");
    }
}
