using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Api.Entities;

public class Message
{
    public uint Id { get; set; }
    public Guid? UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }
    public string? UserMessage { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? PictureUrl { get; set; }
    public string? MediaUrl { get; set; }
    public string? FileUrl { get; set; }
}