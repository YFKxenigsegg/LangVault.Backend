namespace LangVault.CardManager.Infrastructure.Migrations;
/// <summary>
/// Mark all migrations with this INSTEAD of [Migration].
/// </summary>
public class VersionedMigrationAttribute(string description, byte major, byte minor, byte patch, byte number)
    : MigrationAttribute(CalculateValue(major, minor, patch, number))
{
    public string Desctiption => description;

    private static long CalculateValue(byte major, byte minor, byte patch, byte number)
        => major * 1000000L + minor * 1000000L + patch * 10000L + number;
}
