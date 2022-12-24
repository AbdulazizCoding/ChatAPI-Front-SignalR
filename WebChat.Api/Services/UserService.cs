using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebChat.Api.Entities;
using WebChat.Api.ViewModels;

namespace WebChat.Api.Service;

[Authorize]
public class UserService
{
    private readonly UserManager<AppUser> userManager;
    
    public UserService(
        UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<UserViewModel> GetProfile(ClaimsPrincipal claim)
    {
        var user = await userManager.GetUserAsync(claim);
        var result = new UserViewModel()
        {
            UserName = user.UserName
        };
        return result;
    }
}