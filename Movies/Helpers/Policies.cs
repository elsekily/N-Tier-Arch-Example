using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Movies.Helpers;
internal class Policies
{
    public static AuthorizationPolicy Policy(string role)
    {
        var policy = new AuthorizationPolicyBuilder();
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser().RequireRole(role);

        return policy.Build();
    }
}
