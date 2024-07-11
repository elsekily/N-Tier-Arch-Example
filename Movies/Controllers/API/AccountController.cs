using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movies.Application.Services.Core;
using Movies.DataAccess.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Movies.Controllers.API;

[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IConfiguration configuration;
    private readonly IMoviesService moviesService;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMoviesService moviesService)
    {
        this.configuration = configuration;
        this.moviesService = moviesService;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var userFromDb = await userManager.FindByEmailAsync(request.Email);
        
        if(userFromDb == null || !await userManager.CheckPasswordAsync(userFromDb, request.Password))
            return Unauthorized(new { Message = "Email or Password is incorrect" });
        
        
        var tokenString = GenerateJSONWebToken(userFromDb);
        return Ok(new
        {
            userFromDb.Id,
            userFromDb.Email,
            userFromDb.UserName,
            Roles = await userManager.GetRolesAsync(userFromDb),
            Token = tokenString
        });
    }
    private string GenerateJSONWebToken(User user)
    {
        //var userClaims = userManager.GetClaimsAsync(user).Result;
        var claims = new List<Claim>();
        var roles = userManager.GetRolesAsync(user).Result;
        claims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        
        //claims = claims.Union(userClaims.ToList());

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
            );

        return tokenHandler.WriteToken(token);
    }
    [Authorize]
    [HttpPost("test")]
    public async Task<IActionResult> Test()
    {
        var x = await moviesService.GetMoviesAsync(1, null);

        return Ok();
    }
}
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class LogURLMiddleware
{
    private readonly RequestDelegate _next;
    public LogURLMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await Console.Out.WriteLineAsync("here");
        await this._next(context);
        await Console.Out.WriteLineAsync("here");

    }
}
public class TestMiddleware
{
    private readonly RequestDelegate _next;
    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await Console.Out.WriteLineAsync("here");
        await this._next(context);
        await Console.Out.WriteLineAsync("here");

    }
}