using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Candidates.Helpers.filters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
               var result= new UnprocessableEntityObjectResult(context.ModelState);
                result.StatusCode = 400;
                result.Value = ErrorMessages.InvalidModel;
                context.Result =result;
            }
        }
    }
}
