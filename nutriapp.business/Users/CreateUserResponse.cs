namespace nutriapp.business.Users;

public class CreateUserResponse 
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int? UserId { get; set; }
}