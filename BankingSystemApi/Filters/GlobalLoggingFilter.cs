using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystemApi.Filters
{
    public class GlobalLoggingFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Global Action Started");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Global Action Finished");
        }
    }
}
