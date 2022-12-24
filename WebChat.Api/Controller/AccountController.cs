
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebChat.Api.Data;
using WebChat.Api.Dtos;
using WebChat.Api.Entities;
using WebChat.Api.Service;
using WebChat.Api.ViewModels;

namespace WebChat.Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;
    private readonly UserService userService;
    private readonly AppDbContext context;

    public AccountController(
        AppDbContext context,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        UserService userService)
    {
        this.userService = userService;
        this.context = context;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
    {
        if(userManager is null)
            return BadRequest("User Manager bo'sh");

        if (string.IsNullOrWhiteSpace(createUserDto.UserName))
            return BadRequest("Username is empty");

        if (createUserDto.Password != createUserDto.ConfirmPassword)
            return BadRequest("Wrong password");

        var user = new AppUser()
        {
            UserName = createUserDto.UserName
        };
            
        var createdUser = await userManager.CreateAsync(user, createUserDto.Password);
        if (!createdUser.Succeeded)
            return BadRequest("User can't be created");

        await signInManager.SignInAsync(user, true);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        if (string.IsNullOrWhiteSpace(loginUserDto.UserName))
            return BadRequest("Username is empty");

        if (loginUserDto.Password != loginUserDto.ConfirmPassword)
            return BadRequest("Wrong password");

        var userResult = await signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, true, true);
        if (!userResult.Succeeded)
            return BadRequest("User can't Login");

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await userService.GetProfile(User);
        return Ok(user);
    }
}