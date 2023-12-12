namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add Words table", 0, 1, 0, 4)]
public class AddWordsTable : Migration
{
    public override void Up()
    {
        Create.Table("Words")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_Words").Identity()
            .WithColumn("ConstructId").AsInt32().Nullable()
                .ForeignKey("FK_Words_Constructs_ConstructId", "Constructs", "Id")
                .Indexed("IX_Words_ConstructId")
            .WithColumn("Type").AsInt32().NotNullable()
            .WithColumn("CreatedBy").AsFixedLengthString(16).Nullable()
            .WithColumn("CreatedUtc").AsDateTimeOffset().NotNullable()
            .WithColumn("ModifiedUtc").AsDateTimeOffset().Nullable()
            .WithColumn("Value").AsFixedLengthString(32).NotNullable();

        Create.Index("IX_Words_Value_Type")
           .OnTable("Words")
           .OnColumn("Value").Ascending()
           .OnColumn("Type").Ascending();
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Words_Constructs_ConstructId").OnTable("Words");
        Delete.Index("IX_Words_Value_Type").OnTable("Words");
        Delete.Table("Words");
    }
}
