using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Assets.Application.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {

            var user = httpContextAccessor?.HttpContext?.User ?? throw new InvalidOperationException("User context is not present");

            if (user.Identity == null || !user.Identity.IsAuthenticated) return null;

            var userId = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var userEmail = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
            var userRole = user.Claims.Where(u => u.Type == ClaimTypes.Role)!.Select(c => c.Value);

            return new CurrentUser(userId, userEmail, userRole);


        }
    }
}
