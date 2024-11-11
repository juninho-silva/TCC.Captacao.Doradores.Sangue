using Api.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace Api.DTOs
{
    /// <summary>
    /// Validtion
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ValidateModelFilter : IActionFilter
    {
        /// <summary>
        /// On Action Executing
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(
                    e => e.Key,
                    e => string.Join(", ", e.Value.Errors.Select(err => err.ErrorMessage))
                );

                var response = new CustomResponse<object>
                {
                    Status = "Error",
                    NotificationError = errors
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        /// <summary>
        /// On Action Executed
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
