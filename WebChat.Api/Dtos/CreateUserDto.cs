using System.ComponentModel.DataAnnotations;

namespace WebChat.Api.Dtos;

public class CreateUserDto
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? ConfirmPassword { get; set; }
}
