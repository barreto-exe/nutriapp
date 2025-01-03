using System.Text.Json.Serialization;

namespace nutriapp.business.Base;

public class BaseCommandResponse
{
    [JsonIgnore]
    public bool Success { get; set; } = true;
    [JsonIgnore]
    public string? Message { get; set; } = "OK";
}