namespace nutriapp.business;

public class BaseCommandResponse
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; } = "OK";
}