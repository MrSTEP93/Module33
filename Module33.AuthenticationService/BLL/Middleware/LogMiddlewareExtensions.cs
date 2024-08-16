using Microsoft.AspNetCore.Builder;

namespace Module33.AuthenticationService.BLL.Middleware
{
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
