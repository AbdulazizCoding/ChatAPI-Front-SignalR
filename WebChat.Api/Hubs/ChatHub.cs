using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using WebChat.Api.Service;

namespace WebChat.Api.Hubs;

public class ChatHub : Hub
{
    [Authorize]
    public async Task GetProfile()
    {
        var username = Context.User.FindFirstValue(ClaimTypes.Name);
        await Clients.All.SendAsync("Profile", username);
    }
}