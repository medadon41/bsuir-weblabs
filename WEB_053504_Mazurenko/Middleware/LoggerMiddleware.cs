using Microsoft.Extensions.Logging;

namespace WEB_053504_Mazurenko.Middleware
{
    public class LoggerMiddleware
    {
        RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<LoggerMiddleware> logger)
        {
            await _next(context);
            if(context.Response.StatusCode != 200)
            {
                logger.LogInformation($"{DateTime.Now} [INFO] Request {context.Request.Path + context.Request.QueryString} returns status code {context.Response.StatusCode}");
            }

        }
    }
}
