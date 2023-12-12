namespace Infrastructure.Migrations.Migrations;
[VersionedMigration("Add masterdata tables", 0, 1, 0, 1)]
public class AddMasterdataTables : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory").IfExists();

        Create.Table("Tags")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_Tags").Identity()
            .WithColumn("Value").AsString().NotNullable()
                .Unique("IX_Tags_Value")
            .WithColumn("Color").AsFixedLengthString(7).NotNullable()
            .WithColumn("LinguisticElementType").AsInt32().NotNullable()
            .WithColumn("Priority").AsInt32().NotNullable();

        Create.Table("WordTypes")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_WordTypes").Identity()
            .WithColumn("Name").AsFixedLengthString(16).NotNullable()
            .WithColumn("Value").AsInt32().NotNullable()
                .Unique("IX_WordTypes_Value");

        Create.Table("ConstructTypes")
            .WithColumn("Id").AsInt32().PrimaryKey("PK_ConstructTypes").Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Value").AsInt32().NotNullable()
                .Unique("IX_ConstructTypes_Value");
    }

    public override void Down()
    {
        Delete.Table("ConstructTypes");
        Delete.Table("WordTypes");
        Delete.Table("Tags");

        Execute.Sql(@"
            CREATE TABLE IF NOT EXISTS public.""__EFMigrationsHistory""
            (
                ""MigrationId"" character varying(150) COLLATE pg_catalog.""default"" NOT NULL,
                ""ProductVersion"" character varying(32) COLLATE pg_catalog.""default"" NOT NULL,
                CONSTRAINT ""PK___EFMigrationsHistory"" PRIMARY KEY (""MigrationId"")
            )
        ");
    }
}
