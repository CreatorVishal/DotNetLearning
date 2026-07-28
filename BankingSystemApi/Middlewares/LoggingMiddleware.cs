namespace BankingSystemApi.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Request Started...");
            await _next(context);
            Console.WriteLine("Request Finished ...");


        }
    }
}
