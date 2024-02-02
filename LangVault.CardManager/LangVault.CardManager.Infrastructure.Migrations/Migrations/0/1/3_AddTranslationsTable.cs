namespace LangVault.CardManager.Infrastructure.Migrations.Migrations;
[VersionedMigration("Add Translations table", 0, 1, 0, 3)]
public class AddTranslationsTable : Migration
{
    public override void Up()
    {
        Create.Table("Translations")
             .WithColumn("Id").AsInt32().PrimaryKey("PK_Translations").Identity()
             .WithColumn("EditorialCardId").AsInt32().Nullable()
                 .ForeignKey("FK_Translations_EditorialCards_EditorialCardId", "EditorialCards", "Id").OnDelete(Rule.SetNull)
                 .Indexed("IX_Translations_EditorialCardId")
             .WithColumn("CreatedBy").AsString(16).Nullable()
             .WithColumn("CreatedUtc").AsDateTimeOffset().NotNullable()
             .WithColumn("ModifiedUtc").AsDateTimeOffset().Nullable()
            .WithColumn("Value").AsString(64).NotNullable();
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Translations_EditorialCards_EditorialCardId").OnTable("Translations");
        Delete.Table("Translations");
    }
}
