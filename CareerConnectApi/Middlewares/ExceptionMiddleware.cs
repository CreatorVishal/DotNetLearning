namespace CareerConnectApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex}");
                Console.WriteLine(ex.Message);

                context.Response.StatusCode = 500;

                await context.Response.WriteAsync("Something Went Wrong");

            }

        }
    }
}