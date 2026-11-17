using System.ComponentModel.Design.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sicherheitseingabe;

public class LogEintrag
{
    public DateTime Zeit { get; set; }
    public int MitarbeiterID { get; set; }
    public string Terminal { get; set; } = "";
    public bool Erlaubt { get; set; }

}


public static class TerminalStore
{
    private static readonly string FilePath = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Terminallogger.json"));

    private static readonly JsonSerializerOptions optionslog = new()
    {
        WriteIndented = true
    };

    public static List<LogEintrag> Load()
    {
        if (!File.Exists(FilePath))
        {
            return new List<LogEintrag>();
        }
        string json = File.ReadAllText(FilePath);
        List<LogEintrag>? eintraege = JsonSerializer.Deserialize<List<LogEintrag>>(json);
        if (eintraege == null)
        {
            return new List<LogEintrag>();
        }
        return eintraege;
    }
    
    public static void Add(LogEintrag eintrag)
    {
        var alle = Load();
        alle.Add(eintrag);
        File.WriteAllText(FilePath, JsonSerializer.Serialize(alle, optionslog));
    }
} 

