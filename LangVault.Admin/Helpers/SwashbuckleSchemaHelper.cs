namespace LangVault.Admin.Helpers;
public class SwashbuckleSchemaHelper
{
    private readonly Dictionary<string, List<string>> _schemaNameRepetition = new();

    public string GetSchemaId(Type type)
    {
        var id = DefaultSchemaIdSelector(type);
        if (!_schemaNameRepetition.ContainsKey(id)) _schemaNameRepetition.Add(id, []);
        var nameList = _schemaNameRepetition[id];
        var fullName = type.FullName ?? string.Empty;
        if (!string.IsNullOrEmpty(fullName) && !nameList.Contains(fullName)) nameList.Add(fullName);
        var index = nameList.IndexOf(fullName);
        return $"{id}{(index >= 1 ? index.ToString() : string.Empty)}";
    }

    private string DefaultSchemaIdSelector(Type type)
    {
        if (!type.IsConstructedGenericType) return type.Name.Replace("[]", "Array");
        var prefix = type.GetGenericArguments()
            .Select(x => DefaultSchemaIdSelector(x))
            .Aggregate((previous, current) => previous + current);
        return prefix + type.Name.Split('`').First();
    }
}
