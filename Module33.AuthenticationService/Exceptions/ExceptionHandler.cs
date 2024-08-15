using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Module33.AuthenticationService.Exceptions
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        private ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string message = "Произошло исключение, причины выясняются";
            if (context.Exception is CustomException)
            {
                message = context.Exception.Message;
            }
            _logger.WriteError(message);
            
            context.Result = new BadRequestObjectResult(message);
        }
    }
}
