namespace CareerConnectApi.Middlewares
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
            Console.WriteLine("Timing start");

            await _next(context);

            Console.WriteLine("Timing End");
        }
    }
}
