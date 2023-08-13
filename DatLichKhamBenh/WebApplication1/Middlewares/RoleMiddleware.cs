using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RoleMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.Path.ToString();
            if (url.StartsWith("/admin"))
            {
                if (httpContext.Session.GetString("role") == null || httpContext.Session.GetString("role") == "false")
                {
                    httpContext.Response.Redirect("/account/login");
                }
            }
            else if (url.StartsWith("/user"))
            {
                if (httpContext.Session.GetString("role") == null || httpContext.Session.GetString("role") == "true")
                {
                    httpContext.Response.Redirect("/account/login");
                }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RoleMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleMiddleware>();
        }
    }
}
