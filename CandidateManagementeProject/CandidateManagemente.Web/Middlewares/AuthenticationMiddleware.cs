using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            if (context.Request.Path.StartsWithSegments("/Candidate"))
            {
                context.Response.Redirect("/Home/Index");
                return;
            }
        }

        await _next(context);
    }
}
