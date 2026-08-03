using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystemApi.Filters
{
    public class AsyncLoggingFilter : IAsyncActionFilter
    {
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Before Controller");
            await next();
            Console.WriteLine("After Controller");
        }
    }
}
