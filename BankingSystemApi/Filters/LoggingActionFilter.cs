using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystemApi.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            Console.WriteLine("Action Started");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Finished");
        }

       
    }
}
