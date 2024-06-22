using Microsoft.AspNetCore.Identity;
using Movies.Core.Common;

namespace Movies.DataAccess.Identity;

public class User : IdentityUser<int> , IUser
{
}
