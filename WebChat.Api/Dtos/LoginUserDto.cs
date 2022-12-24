namespace WebChat.Api.Dtos;

public class LoginUserDto
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}
