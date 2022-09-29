using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Assignment
{
    public class RequestActionFilter : ActionFilterAttribute, IActionFilter
    {
        public string RequiredRole { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var hearder = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(hearder))
                context.Result = new UnauthorizedObjectResult("user is unauthorized");
        }
    }
}
