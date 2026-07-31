using System.Diagnostics;

namespace BankingSystemApi.Middlewares
{
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;
        public TimingMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"Time Taken : {watch.ElapsedMilliseconds} ms");
        }
    }
}
