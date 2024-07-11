using Microsoft.AspNetCore.Http;
using Movies.Shared.Services.Core;
using System.Security.Claims;

namespace Movies.Shared.Services.Implementation;
public class ClaimService : IClaimService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public ClaimService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        return Int32.Parse(httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }

}