namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add Translations table", 0, 1, 0, 5)]
public class AddTranslationsTable : Migration
{
    public override void Up()
    {
        Create.Table("Translations")
             .WithColumn("Id").AsInt32().PrimaryKey("PK_Translations").Identity()
             .WithColumn("ConstructId").AsInt32().Nullable()
                 .ForeignKey("FK_Translations_Constructs_ConstructId", "Constructs", "Id")
                 .Indexed("IX_Translations_ConstructId")
             .WithColumn("WordId").AsInt32().Nullable()
                 .ForeignKey("FK_Translations_Words_WordId", "Words", "Id").OnDelete(Rule.Cascade)
                 .Indexed("IX_Translations_WordId")
             .WithColumn("Type").AsInt32().NotNullable()
             .WithColumn("CreatedBy").AsFixedLengthString(16).Nullable()
             .WithColumn("CreatedUtc").AsDateTimeOffset().NotNullable()
             .WithColumn("ModifiedUtc").AsDateTimeOffset().Nullable()
            .WithColumn("Value").AsFixedLengthString(64).NotNullable();
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Translations_Words_WordId").OnTable("Translations");
        Delete.ForeignKey("FK_Translations_Constructs_ConstructId").OnTable("Translations");
        Delete.Table("Translations");
    }
}
