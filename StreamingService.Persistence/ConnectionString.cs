namespace StreamingService.Persistence;

public class ConnectionString
{
    public const string SettingsKey = "StreamingServiceDb";
    
    public ConnectionString(string value) => Value = value;
    
    public string Value { get; }

    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;
}