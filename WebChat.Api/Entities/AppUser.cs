using Microsoft.AspNetCore.Identity;

namespace WebChat.Api.Entities;

public class AppUser : IdentityUser<Guid>
{
    public virtual List<Message>? Messages { get; set; }
    public string? AvatarUrl { get; set; }
}
