using System.Text.Json;
using Sicherheitseingabe;

public class EmployeeData
{
    public List<Mitarbeiter> MitarbeiterListe {get;set;} = new();
    public List<SicherheitsKarte> KartenListe {get;set;} = new();
}

public static class EmployeeStore
{
    private static readonly string FilePath = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Employees.json"));

    private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

    public static void Save(EmployeeData daten)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

        string json = JsonSerializer.Serialize(daten, options);
        File.WriteAllText(FilePath, json);
    }

    public static EmployeeData Load()
    {
        if (!File.Exists(FilePath))
            return new EmployeeData();

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<EmployeeData>(json) ?? new EmployeeData();
    }
}
