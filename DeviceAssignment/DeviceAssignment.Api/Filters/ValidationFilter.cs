using DeviceAssigment.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAssignment.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        //public async Task OnActionExecuted(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var errorsInModelState = context.ModelState
        //            .Where(x => x.Value.Errors.Count > 0)
        //            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

        //        var errorResponse = new ErrorResponse();

        //        foreach (var error in errorsInModelState)
        //        {
        //            foreach (var subError in error.Value)
        //            {
        //                var errorModel = new ErrorModel()
        //                {
        //                    FieldName = error.Key,
        //                    Message = subError 
        //                };

        //                errorResponse.Errors.Add(errorModel);
        //            }
        //        }

        //        context.Result = new BadRequestObjectResult(errorResponse);
        //        return;
        //    }

        //    await next();
        //}

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var fieldName = context.ModelState.Keys;

                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
