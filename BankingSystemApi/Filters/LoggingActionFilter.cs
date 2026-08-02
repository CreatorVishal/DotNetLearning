using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingSystemApi.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly string _moduleName;
        public LoggingActionFilter(string moduleName)
        {
            _moduleName = moduleName;
            // You can inject any dependencies here if needed
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(_moduleName);
            Console.WriteLine("Action Started");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Finished");
        }
       


    }
}
