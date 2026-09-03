namespace PeopleConnectApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Before Request");

            Console.WriteLine($"Method: {context.Request.Method}");
            Console.WriteLine($"Path: {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Status Code: {context.Response.StatusCode}");
            Console.WriteLine("After Request");
        }
    }
}
