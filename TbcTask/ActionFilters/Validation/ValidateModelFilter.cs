using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Responses;
using Microsoft.OpenApi.Any;
using TbcTask.Domain.Models.Responses.Base;
using System.Net;

namespace TbcTask.ActionFilters.Validation
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateModelFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();

                foreach (var modelState in context.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(new Response<object>(HttpStatusCode.BadRequest,errors));
            }
        }
    }
}
