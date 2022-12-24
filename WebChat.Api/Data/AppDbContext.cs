using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebChat.Api.Entities;

namespace WebChat.Api.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRolde, Guid>
{
    public DbSet<Message>? Messages { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }
}
