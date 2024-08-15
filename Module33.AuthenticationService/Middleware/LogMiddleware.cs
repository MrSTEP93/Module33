using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Module33.AuthenticationService.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.WriteEvent("Я твой Middleware (шатал) запускал");
            _logger.WriteEvent("httpContext.Request.Host " + httpContext.Request.Host);
            _logger.WriteEvent("httpContext.Connection.RemoteIpAddress " + httpContext.Connection.RemoteIpAddress);
            await _next(httpContext);
        }
    }
}
