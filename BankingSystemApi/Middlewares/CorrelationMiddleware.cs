namespace BankingSystemApi.Middlewares
{
    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;
        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = Guid.NewGuid().ToString();
            context.Items["CorrelationId"] = correlationId;            
            context.Response.Headers.Add("X-Correlation-ID", correlationId);
            await _next(context);
        }
    }
}
