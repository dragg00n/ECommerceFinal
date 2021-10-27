using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public bool IncludeModelState { get; set; } = false;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                if (IncludeModelState)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                } else
                {
                    context.Result = new BadRequestResult();
                }
            }
        }
    }
}
