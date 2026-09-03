namespace PeopleConnectApi.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;

        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/maintenance"))
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;

                await context.Response.WriteAsync(
                    "PeopleConnect API is currently under maintenance.");

                return;
            }

            await _next(context);
        }
    }
}