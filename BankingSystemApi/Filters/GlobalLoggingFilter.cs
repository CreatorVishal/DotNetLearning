using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystemApi.Filters
{
    public class GlobalLoggingFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Global Action Started");
            Console.WriteLine(context.ActionDescriptor.DisplayName);
            Console.WriteLine(context.ActionArguments);
            foreach (var argument in context.ActionArguments)
            {
                Console.WriteLine($"Parameter Name : {argument.Key}");
                Console.WriteLine($"Parameter Value : {argument.Value}");
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Global Action Finished");
        }
    }
}
